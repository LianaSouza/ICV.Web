using ICV.WebApi.EF.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebApi.EF.Context
{
    public class DoacaoConfiguration : IEntityTypeConfiguration<Doacao>
    {
        public void Configure(EntityTypeBuilder<Doacao> builder)
        {
            builder
                .ToTable("TblEntradaDoacao");

            builder
                .HasKey(c => c.IdEntradaDoacao);
        }
    }
}
