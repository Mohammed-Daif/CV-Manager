using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace CV_Manager.DB
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Count();
        public Task<ViewModel> Get<ViewModel>(int Id);
        Task<TEntity> Get(int Id, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<ViewModel> GetAllWhere<ViewModel>(Expression<Func<TEntity, bool>> filter);
        PaginationResult<ViewModel> GetAllPagination<ViewModel>(Expression<Func<TEntity, dynamic>> OrderBy, int pageNumber, int pageSize);
        Task<EntityEntry<TEntity>> Add(TEntity entity);
        Task<EntityEntry<TEntity>> Remove(int id);
        Task Update(TEntity entity);
    }

}

