using ICV.WebApi.EF.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ICV.WebApi.EF.Context
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


