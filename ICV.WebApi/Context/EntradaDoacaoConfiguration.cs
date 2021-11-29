using ICV.WebApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICV.WebApi.Context
{
    public class EntradaDoacaoConfiguration : IEntityTypeConfiguration<EntradaDoacao>
    {
        public void Configure(EntityTypeBuilder<EntradaDoacao> builder)
        {
            builder
                .ToTable("TblEntradaDoacao");

            builder
                .HasKey(a => a.IdEntradaDoacao);
        }
    }
}
