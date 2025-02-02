using System.Linq.Expressions;

namespace DynamicDataQueries.Abstraction;

public abstract class QueryServiceBase<T> : IQueryService<T>
{
    public IEnumerable<T> Filter(IEnumerable<T> data, Expression<Func<T, bool>> predicate)
    {
       if(predicate is null) throw new ArgumentNullException(nameof(predicate));
       return data.AsQueryable().Where(predicate);
    }
    public IEnumerable<T> Sort(IEnumerable<T> data, Expression<Func<T, object>> sortExpression, bool ascending = true)
    {
        if (sortExpression == null) throw new ArgumentNullException(nameof(sortExpression));

        return ascending
            ? data.AsQueryable().OrderBy(sortExpression)
            : data.AsQueryable().OrderByDescending(sortExpression);
    }

    public IEnumerable<TResult> Transform<TResult>(IEnumerable<T> items, Func<T, TResult> transformExpression)
    {
        if (transformExpression == null) throw new ArgumentNullException(nameof(transformExpression));
        return items.Select(transformExpression);
    }
    public abstract IEnumerable<T> ApplyQueryPipeline(
        IEnumerable<T> items,
        Expression<Func<T, bool>> filterExpression, 
        Expression<Func<T, object>> sortExpression, 
        bool ascending = true);
}
