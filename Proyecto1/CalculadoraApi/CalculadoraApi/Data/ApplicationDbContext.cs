using CalculadoraApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Calculo> Calculos { get; set; }
    }
}
