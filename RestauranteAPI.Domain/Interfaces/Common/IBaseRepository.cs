using RestauranteAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Domain.Interfaces.Common
{
    // se usa <T> porque para ser common ele deve aceitar qualquer tipo genérico
    // e nao especifico como cidade por exemplo
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        IQueryable<T> GetAll(); 
        IQueryable<T> GetById(Guid id);
        Task<bool> Any(Guid id);
    }
}
