using Backend.Models.Enums;
using Backend.Models;

namespace Backend.Helpers
{
    public class FilterSelections
    {
        public string Name { get; set; } = "";
       
        public static IQueryable<Selection> FilterData(IQueryable<Selection> data, FilterSelections filter)
        {
            if (filter == null)
                return data;
            return data.Where(x => x.Name.ToLower().StartsWith(filter.Name.ToLower()));
  
        }
    }
}
