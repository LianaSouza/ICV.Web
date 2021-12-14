using ICV.WebApi.EF.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ICV.WebApi.EF.Context
{
    public class BeneficiadoConfiguration : IEntityTypeConfiguration<TblBeneficiado>
    {
        public void Configure(EntityTypeBuilder<TblBeneficiado> builder)
        {
            builder
                .ToTable("TblBeneficiado");

            builder
                .HasKey(c => c.IdBeneficiado);
        }
    }
}