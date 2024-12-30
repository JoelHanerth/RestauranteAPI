using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Domain.Interfaces;
using RestauranteAPI.Infrastructure.Context;
using RestauranteAPI.Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Infrastructure.Repositories
{
    internal class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
