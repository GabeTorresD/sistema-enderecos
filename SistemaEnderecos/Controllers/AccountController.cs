using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEnderecos.Data;
using SistemaEnderecos.Models;

namespace SistemaEnderecos.Controllers
{
    public class AccountController : Controller
    {
        //Adiciona o DbContext
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        //Get conta e login
        [HttpGet]
        public IActionResult Login()
        {
            //Se estiver logado vai redirecionar pra endereços
            if (HttpContext.Session.GetInt32("UsuarioId") != null)
                return RedirectToAction("Index", "Endereco");

            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //Busca o usuario pelo login
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Login == model.Login);

            //Verfica se usuario existe e se a senha está correta
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(model.Senha, usuario.Senha))
            {
                ModelState.AddModelError("", "Usuário ou senha inválidos. ");
                return View(model);
            }

            //Salvar o usuario na sessao
            HttpContext.Session.SetInt32("UsuarioID", usuario.Id);
            HttpContext.Session.SetString("UsuarioNome", usuario.Nome);

            return RedirectToAction("Index", "Endereco");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}