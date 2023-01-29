using AutoMapper;
using CV_Manager.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace CV_Manager.DB
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _entities;
        protected readonly IMapper _mapper;
        protected readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _entities = context.Set<TEntity>();
        }
        public async Task<EntityEntry<TEntity>> Add(TEntity entity)
        {
            var addEntity = await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return addEntity;
        }

        public int Count()
        {
            return _entities.Count();
        }

        public async Task<ViewModel> Get<ViewModel>(int Id)
        {
            return _mapper.ProjectTo<ViewModel>(_entities.Where(e => (e as BaseModel).Id == Id)).FirstOrDefault();

        }
        public async Task<TEntity> Get(int Id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _entities.Where(e => (e as BaseModel).Id == Id);
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return query.FirstOrDefault();
        }
        public async Task<TEntity> Get(int Id)
        {
            return await _entities.FindAsync(Id);
        }
        public PaginationResult<ViewModel> GetAllPagination<ViewModel>(Expression<Func<TEntity, dynamic>> OrderBy, int index, int size)
        {
            return new PaginationResult<ViewModel> { data = _mapper.ProjectTo<ViewModel>(_entities.OrderByDescending(OrderBy).Skip(index * size).Take(size)).ToList(), count = _entities.Count() };
        }

        public IEnumerable<ViewModel> GetAllWhere<ViewModel>(Expression<Func<TEntity, bool>> filter)
        {
            return _mapper.ProjectTo<ViewModel>(_entities.Where(filter)).ToList();
        }

        public async Task<EntityEntry<TEntity>> Remove(int id)
        {
            var entity = await _entities.FindAsync(id);
            var deletedEntity = _entities.Remove(entity);
            await _context.SaveChangesAsync();
            return deletedEntity;
        }

        public async Task Update(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
