using Backend.Models.Enums;

namespace Backend.Helpers
{
    public class UserParams
    {
        public int PageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value;
        }

        public FilterApplications? filter { get; set; }
        public FilterSelections? filterSelections { get; set; }

        public string? OrderBy { get; set; }
    }
}
