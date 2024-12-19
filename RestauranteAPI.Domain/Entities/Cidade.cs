using RestauranteAPI.Domain.Common;
using RestauranteAPI.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Domain.Entities
{
    public class Cidade : BaseEntity
    {
        public string Nome { get; set; }
        public List<Cliente> Clientes { get; set; } = [];

        public Cidade(string nome)
        {
            var validationErrors = CidadeValidator(nome);
            if (validationErrors.Count > 0)
            {
                throw new DomainValidationException(validationErrors);
            }
            Nome = nome;
        }

        private List<string> CidadeValidator(string nome)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(nome))
            {
                errors.Add("O campo nome de Cidade é obrigatório");
            }

            return errors;
        }
    }
}
