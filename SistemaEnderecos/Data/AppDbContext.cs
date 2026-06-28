using Microsoft.EntityFrameworkCore;
using SistemaEnderecos.Models;

namespace SistemaEnderecos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraçao de relacionamento
            modelBuilder.Entity<Endereco>()
                //1 pra muitos
                    .HasOne(e => e.Usuario)
                    .WithMany(u => u.Enderecos)
                    .HasForeignKey(e => e.UsuarioID)
                //Deleta todos os endereços um usuario se esse for deletado
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}