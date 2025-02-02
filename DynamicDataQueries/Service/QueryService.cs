using DynamicDataQueries.Abstraction;
using System.Linq.Expressions;

namespace DynamicDataQueries.Service;

public class QueryService<T> : QueryServiceBase<T>
{
    public override IEnumerable<T> ApplyQueryPipeline(
        IEnumerable<T> items,
        Expression<Func<T, bool>> filterExpression,
        Expression<Func<T, object>> sortExpression, 
        bool ascending = true)
    {
        if (filterExpression != null)
        {
            items = Filter(items, filterExpression); // Apply filter
        }

        if (sortExpression != null)
        {
            items = Sort(items, sortExpression, ascending); // Apply sorting
        }

        return items;
    }
}
