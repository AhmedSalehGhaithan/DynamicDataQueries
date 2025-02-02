using System.Linq.Expressions;

namespace DynamicDataQueries.Abstraction;

public interface IQueryService<T>
{
    IEnumerable<T> Filter(
        IEnumerable<T> data,
        Expression<Func<T,bool>> predicate);

    IEnumerable<T> Sort(
        IEnumerable<T> data,
        Expression<Func<T, object>> sortExpression, 
        bool ascending = true);

    IEnumerable<TResult> Transform<TResult>(
        IEnumerable<T> items,
        Func<T, TResult> transformExpression);

    IEnumerable<T> ApplyQueryPipeline(
        IEnumerable<T> data,
        Expression<Func<T, bool>> filterExpression,
        Expression<Func<T, object>> sortExpression,
        bool ascending = true);
}
