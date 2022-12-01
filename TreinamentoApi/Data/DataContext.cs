using Microsoft.EntityFrameworkCore;
using TreinamentoApi.Models;

namespace TreinamentoApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Person> person { get; set; }
    }
}
