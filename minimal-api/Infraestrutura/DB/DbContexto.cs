using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Infraestrutura.DB
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration _config;

        public DbContexto(IConfiguration config)
        { 
            _config = config;
        }

        public DbSet<Administrador> Administradores { get; set; } = default!;
        public DbSet<Veiculo> Veiculos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                    new Administrador("admin@teste.com", "12345", "adm")
                    {
                        Id = 1
                    }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _config.GetConnectionString("SqlServer")?.ToString();
            if(!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
           
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}