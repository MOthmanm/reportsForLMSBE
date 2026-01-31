using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartBack.Domain.Helpers
{
    public class FindOptions
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortBy { get; set; }
        public bool Desc { get; set; } = false;

        public string? Search { get; set; } // Add this property
        //public Dictionary<string, object>? Filters { get; set; }

        public List<FilterCriteria>? Filters { get; set; } // Replace Dictionary with FilterCriteria



    }
}
