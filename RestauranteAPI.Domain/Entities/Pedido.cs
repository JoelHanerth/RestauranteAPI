using RestauranteAPI.Domain.Common;
using RestauranteAPI.Domain.Enums;
using RestauranteAPI.Domain.Validation;

namespace RestauranteAPI.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public DateTimeOffset Data { get; set; }
        public decimal Valor { get; set; }
        public EstadoPedido EstadoPedido { get; set; }
        public Guid PedidoClienteId { get; set; }
        public Cliente? Cliente { get; set; } 

        public Pedido(DateTimeOffset data, decimal valor, Guid pedidoClienteId)
        {
            var validationErrors = PedidoValidator(data, valor, pedidoClienteId);

            if (validationErrors.Count > 0)
            {
                throw new DomainValidationException(validationErrors);
            }
            Data = data;
            Valor = valor;
            PedidoClienteId = pedidoClienteId;
        }

        public List<string> PedidoValidator(DateTimeOffset data, decimal valor, Guid pedidoClienteId)
        {
            var erros = new List<string>();

            if (data == default)
            {
                erros.Add("O campo Data de pedido é obrigatório");
            }

            if (valor == default)
            {
                erros.Add("O campo Valor de pedido é obrigatório");
            }

            if (valor <= 0)
            {
                erros.Add("O campo valor de Pedido não pode ser negativo");
            }
            if (pedidoClienteId == Guid.Empty)
            {
                erros.Add("O Id de cliente em Pedido não pode ser vazio");
            }

            return erros;
        }
    }
}
