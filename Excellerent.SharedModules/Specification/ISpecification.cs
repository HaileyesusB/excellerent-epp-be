using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.SharedModules.Specification
{
    public interface ISpecification<TEntity>
    {
        TEntity SatisfyingEntityFrom(IQueryable<TEntity> query);

        IQueryable<TEntity> SatisfyingEntitiesFrom(IQueryable<TEntity> query);
    }
}
