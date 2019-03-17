using BlogApp.BLL.Abstract;
using BlogApp.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogApp.BLL.Concrete
{
    public class BaseRepository<TEntity, TId, TContext> : IBaseRepository<TEntity, TId, TContext>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        private readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                //var addedData = _context.Entry<TEntity>(entity);
                //addedData.State = EntityState.Added;

                _context.Set<TEntity>().Add(entity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            List<TEntity> list;
            if (filter == null)
            {
                list = _context.Set<TEntity>().ToList();
            }
            else
            {
                list = _context.Set<TEntity>().Where(filter).ToList();
            }

            return list;
        }
        public bool Update(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
