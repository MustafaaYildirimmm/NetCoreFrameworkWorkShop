using NetCoreFrameworkWorkShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity :class,IEntity,new()
    {
        TEntity FirstOrDefault(Expression<Func<TEntity,bool>> filter);
        TEntity LastOrDefault(Expression<Func<TEntity,bool>> filter);
        TEntity SingleOrDefault(Expression<Func<TEntity,bool>> filter);
        IList<TEntity> GetList(Expression<Func<TEntity,bool>> filter = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
