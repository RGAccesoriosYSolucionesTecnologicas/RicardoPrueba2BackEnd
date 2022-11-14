using Microsoft.EntityFrameworkCore;

namespace RicardoPrueba2.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=NITRO5;Initial Catalog=Prueba2ProfeJorge;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Colaborador>().HasKey(x => x.Rut);
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Departamento>().HasKey(x => x.DepartamentoId);

        }
    }
}
