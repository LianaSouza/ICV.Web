using ICV.WebApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ICV.WebApi.Context
{
    public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder
                .ToTable("TblColaborador");

            builder
                .HasKey(c => c.IdColaborador);
        }
    }
}


