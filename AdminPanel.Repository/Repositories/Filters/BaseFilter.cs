using AdminPanel.Domain.Enums;
using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AdminPanel.Repository.Repositories.Filters;

namespace AdminPanel.Repository.Repositories.Filters
{
    public class BaseFilter
    {
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public int LastRow { get; set; }
        public string SortColumn { get; set; }
        public SortOrder SortOrder { get; set; }
        public int Take => 1 + EndRow - StartRow;
    }
}
