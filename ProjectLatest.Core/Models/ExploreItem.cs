using ProjectLatest.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLatest.Core.Models
{
    public class ExploreItem : AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int RatingCount { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public bool? IsActive { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
