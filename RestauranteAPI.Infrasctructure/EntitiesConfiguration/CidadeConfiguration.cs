using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Infrastructure.EntitiesConfiguration
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.HasIndex(x => x.Nome).IsUnique();
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();

            builder
                .HasMany(cidade => cidade.Clientes)
                .WithOne(cliente => cliente.Cidade)
                .HasForeignKey(cliente => cliente.ClienteCidadeId);
        }
    }
}
