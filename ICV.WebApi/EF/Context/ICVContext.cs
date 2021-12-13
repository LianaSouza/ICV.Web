using ICV.WebApi.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace ICV.WebApi.EF.Context
{
    public class ICVContext : DbContext
    {
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Doador> Doador { get; set; }
        public DbSet<Doacao> Doacao { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=icv.database.windows.net;Initial Catalog=ICV;User ID=liana;Password=icv#2021@;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradorConfiguration());
            modelBuilder.ApplyConfiguration(new DoadorConfiguration());
            modelBuilder.ApplyConfiguration(new DoacaoConfiguration());
        }
    }
}
