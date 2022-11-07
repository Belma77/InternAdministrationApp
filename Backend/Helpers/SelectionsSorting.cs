using Backend.Models;

namespace Backend.Helpers
{
    public class SelectionsSorting
    {
        public static IQueryable<Selection> SortBy(IQueryable<Selection> query, string? sort)
        {
            switch (sort)
            {
                case "Ascending":
                    {
                        query = query.OrderBy(u => u.Name);
                        break;
                    }
                case "Descending":
                    {
                        query = query.OrderByDescending(u => u.Name);
                        break;
                    }

                default:
                    {
                        query = query.OrderBy(u => u.Name);
                        break;
                    }
            }

            return query;
        }
    }
}
