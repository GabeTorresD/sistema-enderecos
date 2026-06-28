using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEnderecos.Data;
using SistemaEnderecos.Models;
using System.Text;

namespace SistemaEnderecos.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly AppDbContext _context;

        public EnderecoController(AppDbContext context)
        {
            _context = context;
        }

        // Verifica se o usuário está logado
        private int? GetUsuarioId()
        {
            return HttpContext.Session.GetInt32("UsuarioId");
        }

        // GET: /Endereco/Index
        public async Task<IActionResult> Index()
        {
            var usuarioId = GetUsuarioId();
            if (usuarioId == null)
                return RedirectToAction("Login", "Account");

            var enderecos = await _context.Enderecos
                .Where(e => e.UsuarioId == usuarioId)
                .ToListAsync();

            ViewBag.UsuarioNome = HttpContext.Session.GetString("UsuarioNome");
            return View(enderecos);
        }

        // GET: /Endereco/Criar
        public IActionResult Criar()
        {
            if (GetUsuarioId() == null)
                return RedirectToAction("Login", "Account");

            return View(new EnderecoViewModel());
        }

        // POST: /Endereco/Criar
        [HttpPost]
        public async Task<IActionResult> Criar(EnderecoViewModel model)
        {
            if (GetUsuarioId() == null)
                return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
                return View(model);

            var endereco = new Endereco
            {
                Cep = model.Cep,
                Logradouro = model.Logradouro,
                Complemento = model.Complemento,
                Bairro = model.Bairro,
                Cidade = model.Cidade,
                Uf = model.Uf,
                Numero = model.Numero,
                UsuarioId = GetUsuarioId()!.Value
            };

            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: /Endereco/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var usuarioId = GetUsuarioId();
            if (usuarioId == null)
                return RedirectToAction("Login", "Account");

            var endereco = await _context.Enderecos
                .FirstOrDefaultAsync(e => e.Id == id && e.UsuarioId == usuarioId);

            if (endereco == null)
                return NotFound();

            var model = new EnderecoViewModel
            {
                Id = endereco.Id,
                Cep = endereco.Cep,
                Logradouro = endereco.Logradouro,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Uf = endereco.Uf,
                Numero = endereco.Numero
            };

            return View(model);
        }

        // POST: /Endereco/Editar/5
        [HttpPost]
        public async Task<IActionResult> Editar(EnderecoViewModel model)
        {
            var usuarioId = GetUsuarioId();
            if (usuarioId == null)
                return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
                return View(model);

            var endereco = await _context.Enderecos
                .FirstOrDefaultAsync(e => e.Id == model.Id && e.UsuarioId == usuarioId);

            if (endereco == null)
                return NotFound();

            endereco.Cep = model.Cep;
            endereco.Logradouro = model.Logradouro;
            endereco.Complemento = model.Complemento;
            endereco.Bairro = model.Bairro;
            endereco.Cidade = model.Cidade;
            endereco.Uf = model.Uf;
            endereco.Numero = model.Numero;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // POST: /Endereco/Deletar/5
        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            var usuarioId = GetUsuarioId();
            if (usuarioId == null)
                return RedirectToAction("Login", "Account");

            var endereco = await _context.Enderecos
                .FirstOrDefaultAsync(e => e.Id == id && e.UsuarioId == usuarioId);

            if (endereco != null)
            {
                _context.Enderecos.Remove(endereco);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        // GET: /Endereco/ExportarCsv
        public async Task<IActionResult> ExportarCsv()
        {
            var usuarioId = GetUsuarioId();
            if (usuarioId == null)
                return RedirectToAction("Login", "Account");

            var enderecos = await _context.Enderecos
                .Where(e => e.UsuarioId == usuarioId)
                .ToListAsync();

            var csv = new StringBuilder();
            csv.AppendLine("CEP,Logradouro,Complemento,Bairro,Cidade,UF,Numero");

            foreach (var e in enderecos)
            {
                csv.AppendLine($"{e.Cep},{e.Logradouro},{e.Complemento},{e.Bairro},{e.Cidade},{e.Uf},{e.Numero}");
            }

            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            return File(bytes, "text/csv", "enderecos.csv");
        }
    }
}