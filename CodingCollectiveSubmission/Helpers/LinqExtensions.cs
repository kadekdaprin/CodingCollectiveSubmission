using CodingCollectiveSubmission.Models;
using System.Linq.Expressions;

namespace CodingCollectiveSubmission.Helpers
{
    public static class LinqExtensions
    {
        public static IQueryable<T> ConditionalWhere<T>(
            this IQueryable<T> source,
            Func<bool> condition,
            Expression<Func<T, bool>> predicate)
        {
            if (condition())
            {
                return source.Where(predicate);
            }

            return source;
        }

        public static IQueryable<TSource> ConditionalOrderBy<TSource, TKey>(
            this IQueryable<TSource> source,
            string orderByType,
            Func<bool> condition,
            Expression<Func<TSource, TKey>> keySelector)
        {
            if (condition())
            {
                if (orderByType == "asc")
                {
                    return source.OrderBy(keySelector);
                }
                else
                {
                    return source.OrderByDescending(keySelector);
                }
            }

            return source;
        }
    }
}
