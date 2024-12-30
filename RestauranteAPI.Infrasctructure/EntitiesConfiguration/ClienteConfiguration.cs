using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using RestauranteAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Infrastructure.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(cliente => cliente.Id);
            builder.Property(cliente => cliente.Nome);
            builder.Property(cliente => cliente.Telefone);

            builder.HasIndex(cliente => cliente.Cpf).IsUnique();

            builder
                .HasOne(cliente => cliente.Cidade)
                .WithMany(cidade => cidade.Clientes)
                .HasForeignKey(cidade => cidade.ClienteCidadeId);
        }
    }
}
