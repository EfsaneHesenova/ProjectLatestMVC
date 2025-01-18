using ProjectLatest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLatest.BL.DTOs.CategoryDtos
{
    public class CategoryPutDto
    {
        public string Title { get; set; }
        public ICollection<ExploreItem>? ExploreItems { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
