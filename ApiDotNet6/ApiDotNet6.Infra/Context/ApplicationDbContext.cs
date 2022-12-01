using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDotNet6.Domain.Entities;

namespace ApiDotNet6.Infra.Data.Context
{
    // Classe responsável pela conexão do banco de dados que para esse projeto estamos usando MYSQL, onde vai ficar o mapeamento das clases com as tabelas
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        // Fazendo o mapeamento da entidade com a tabela do banco de dados.
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
