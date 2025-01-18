using Microsoft.EntityFrameworkCore;
using ProjectLatest.Core.Models.Common;
using ProjectLatest.DAL.Contexts;
using ProjectLatest.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLatest.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            return true;
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public IQueryable<T> GetAllByConditionAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = Table.AsQueryable();
            query = query.Where(condition);
            return query;

        }

        public async Task<T> GetByIdAsync(int id, params string[] includes)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (includes.Length > 0)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }
            T? entity = await Table.SingleOrDefaultAsync(x => x.Id == id);
            return entity;

        }

        public async Task<T> GetSingleByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = Table.AsQueryable();
            T? entity = await query.SingleOrDefaultAsync(condition);
            return entity;
        }

        public async Task<bool> IsExist(int id)
        {
          return await Table.AnyAsync(x => x.Id == id);
             
        }

        public async Task<int> SaveChangesAsync()
        {
            int rows = await _context.SaveChangesAsync();
            return rows;
        }

        public void Update(T entity)
        {
           Table.Update(entity);
        }
    }
}
