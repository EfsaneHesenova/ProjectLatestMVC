using Microsoft.EntityFrameworkCore;
using ProjectLatest.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLatest.DAL.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        DbSet<T> Table {  get; }

        //write
        Task<bool> CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
        Task<bool> IsExist(int id);

        //Read
        Task<ICollection<T>> GetAllAsync();
        IQueryable<T> GetAllByConditionAsync(Expression<Func<T, bool>> condition);
        Task<T> GetSingleByCondition(Expression<Func<T, bool>> condition);
        Task<T> GetByIdAsync(int id, params string[] includes);

    }
}
