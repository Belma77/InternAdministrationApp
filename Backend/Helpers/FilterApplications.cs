using Backend.Models;
using Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Backend.Helpers
{
    public class FilterApplications
    {
        public string Name { get; set; } = "";
        public Status? Status { get; set; }
        public  EducationLevel? EducationLevel { get; set; }
        public static IQueryable<Applications> FilterData(IQueryable<Applications> data, FilterApplications filter)
        {
            if (filter == null)
                return data;
            
            data = data.Where(x => x.FirstName.ToLower().StartsWith(filter.Name.ToLower()) || x.LastName.ToLower().StartsWith(filter.Name.ToLower()) || (x.FirstName.ToLower()+" "+x.LastName.ToLower()).StartsWith(filter.Name.ToLower()));

            if (filter.EducationLevel.HasValue)
            {
                data=data.Where(x=>x.EducationLevel==filter.EducationLevel);
            }
            if (filter.Status.HasValue)
                data=data.Where(x=>x.Status==filter.Status);
            return data;
        }
    }
}
