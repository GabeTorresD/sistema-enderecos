using Microsoft.EntityFrameworkCore;
using SistemaEnderecos.Data;

var builder = WebApplication.CreateBuilder(args);

//Seta o DBContext (o banco de dados)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Registrar a sessão pra fazer login
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Rota inicial
builder.Services.AddControllersWithViews();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if(!context.Usuarios.Any())
    {
        context.Usuarios.Add(new SistemaEnderecos.Models.Usuario
        {
            Nome = "Administrador",
            Login = "Admin",
            Senha = BCrypt.Net.BCrypt.HashPassword("admin123")
        });
        context.SaveChanges();
    }
}

    app.Run();