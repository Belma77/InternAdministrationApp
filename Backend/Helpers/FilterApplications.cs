using Backend.Models;
using Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Backend.Helpers
{
    public class FilterApplications
    {
        public string Name { get; set; } = "";
        public StatusEnum? Status { get; set; }
        public  EducationLevelEnum? EducationLevel { get; set; }
        public static IQueryable<Applications> ExtentQueryWithFilter (IQueryable<Applications> query, FilterApplications filter)
        {
            if (filter == null)
                return query;

            query = query.Where(x => x.FirstName.ToLower().StartsWith(filter.Name.ToLower()) || x.LastName.ToLower().StartsWith(filter.Name.ToLower()) || (x.FirstName.ToLower()+" "+x.LastName.ToLower()).StartsWith(filter.Name.ToLower()));

            if (filter.EducationLevel.HasValue)
            {
                query = query.Where(x=>x.EducationLevel==filter.EducationLevel);
            }
            if (filter.Status.HasValue)
                query = query.Where(x=>x.Status==filter.Status);
            return query;
        }
    }
}
