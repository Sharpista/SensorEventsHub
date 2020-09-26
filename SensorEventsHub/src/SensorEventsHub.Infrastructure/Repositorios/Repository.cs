using Microsoft.EntityFrameworkCore;
using SensorEventsHub.Domain.Enitidades;
using SensorEventsHub.Domain.Interfaces.Repositorios;
using SensorEventsHub.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SensorEventsHub.Infrastructure.Repositorios
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly SensorContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(SensorContext sensorContext)
        {
            Db = sensorContext;
            DbSet = sensorContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> BuscarPorQualquerParametro(Expression<Func<TEntity, bool>> predicado)
        {
            return await DbSet.AsNoTracking().Where(predicado).ToListAsync();
        }


        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return  await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
