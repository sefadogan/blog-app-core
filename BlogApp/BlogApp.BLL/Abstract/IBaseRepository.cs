using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BlogApp.BLL.Abstract
{
    public interface IBaseRepository<TEntity, TId, TContext>
        where TEntity : class
        where TContext : DbContext
    {
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
    }
}
