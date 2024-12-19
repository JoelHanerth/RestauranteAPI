using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Domain.Validation
{
    public class DomainValidationException: Exception
    {
        public List<string> Errors { get;}

        public DomainValidationException(List<string> errors)
        {
            Errors = errors;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Errors);
        }
    }
}
 