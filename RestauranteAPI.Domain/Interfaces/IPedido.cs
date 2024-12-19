using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Domain.Interfaces
{
    public interface IPedido: IBaseRepository<Pedido>
    {
    }
}
