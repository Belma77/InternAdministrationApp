using Backend.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Backend.Helpers
{
    public class AppsSorting
    {
        public static  IQueryable<Applications> SortBy(IQueryable<Applications> query,string sort)
        {
            switch (sort)
            {
              case "Ascending":
              {
                 query = query.OrderBy(u => u.FirstName);
                 break;
              }
                case "Descending":
                    {
                        query = query.OrderByDescending(u => u.FirstName);
                        break;
                    }

                default:
                    {
                        query = query.OrderBy(u => u.FirstName);
                        break;
                    }
            }
            
            return query;
        }
    }
}
