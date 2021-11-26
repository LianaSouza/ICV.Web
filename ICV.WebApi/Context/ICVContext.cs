using ICV.WebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace ICV.WebApi.Context
{
    public class ICVContext : DbContext
    {
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Doador> Doador { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ICV;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }       
}
