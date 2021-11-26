using ICV.WebApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICV.WebApi.Context
{
    public class DoadorConfiguration : IEntityTypeConfiguration<Doador>
    {
        public void Configure(EntityTypeBuilder<Doador> builder)
        {
            builder
                            .ToTable("TblDoador");

            builder
                            .HasKey(c => c.IdDoador);
        }
    }
}
