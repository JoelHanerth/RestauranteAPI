using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Infrastructure.EntitiesConfiguration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(Pedido => Pedido.Id);
            builder.Property(Pedido => Pedido.Data).IsRequired();
            builder.Property(Pedido => Pedido.Valor).IsRequired();
            builder.Property(Pedido => Pedido.EstadoPedido).IsRequired();
        }
    }
}
