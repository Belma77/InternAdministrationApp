using Backend.Models.Enums;
using Backend.Models;

namespace Backend.Helpers
{
    public class FilterSelections
    {
        public string Name { get; set; } = "";
       
        public static IQueryable<Selection> ExtentQueryWithFilter(IQueryable<Selection> query, FilterSelections filter)
        {
            if (filter == null)
                return query;
            return query.Where(x => x.Name.ToLower().StartsWith(filter.Name.ToLower()));
  
        }
    }
}
