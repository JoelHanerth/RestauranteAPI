using RestauranteAPI.Domain.Common;
using RestauranteAPI.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public Guid ClienteCidadeId { get; set; }
        public Cidade? Cidade { get; set; } //usado so quando tiver tirando a informacao do banco
        public List<Pedido> Pedidos { get; set; } = [];

        public Cliente(string nome, string telefone, string cpf, Guid clienteCidadeId)
        {  
            var validationErrors = ClienteValidator(nome, telefone, cpf, clienteCidadeId);

            if (validationErrors.Count > 0)
            {
                throw new DomainValidationException(validationErrors);
            }
            Nome = nome;
            Telefone = telefone;
            Cpf = cpf;
            ClienteCidadeId = clienteCidadeId;
        }

        public List<string> ClienteValidator(string nome, string telefone, string cpf, Guid clienteCidadeId)
        {
            var erros = new List<string>();

            if (string.IsNullOrEmpty(nome))
            {
                erros.Add("O campo cidade é obrigatório");
            }

            if (string.IsNullOrEmpty(telefone))
            {
                erros.Add("O campo telefone é obrigatório");
            }

            if (string.IsNullOrEmpty(cpf))
            {
                erros.Add("O campo cpf é obrigatório");
            }
            if (clienteCidadeId == Guid.Empty)
            {
                erros.Add("O Id de cidade em Cliente não pode ser vazio");
            }

            return erros;
        }
    }
}
