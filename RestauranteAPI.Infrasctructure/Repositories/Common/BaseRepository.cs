using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Domain.Common;
using RestauranteAPI.Domain.Interfaces.Common;
using RestauranteAPI.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Infrastructure.Repositories.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(AppDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task<bool> Any(Guid id) 
        {
            return await DbSet.AnyAsync(x => x.Id.Equals(id));
        }

        public async Task Create(T entity)
        {
            await Context.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            entity.Delete();
            await Task.Run(() => Context.Remove(entity), new CancellationToken());
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<T> GetById(Guid id)
        {
            return DbSet
                .Where(x => x.Id == id)
                .AsNoTracking()
                .AsQueryable();

        }

        public async Task Update(T entity)
        {
            await Task.Run(() => Context.Update(entity), new CancellationToken());
        }
    }
}
