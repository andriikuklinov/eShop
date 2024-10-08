using DataAccess.Common.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Common
{
    public class GenericRepository<T, TContext> : IGenericRepository<T> where T : class where TContext : DbContext
    {
        private readonly TContext _context;

        public GenericRepository(TContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            var entryEntity = _context.Attach(entity);
            entryEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<T> DeleteAsync(T entity)
        {
            var entryEntity = _context.Attach(entity);
            entryEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            return entities;
        }
        public async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            await _context.SaveChangesAsync();

            return entities;
        }
        public async Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();

            return entities;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                return _context.Set<T>().AsQueryable<T>();
            return _context.Set<T>().Where(predicate);
        }

        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicate, cancellationToken);
        }
    }
}
