using Microsoft.AspNetCore.Http;
using ProjectLatest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectLatest.BL.DTOs.ExploreItemDtos
{
    public class ExploreItemPutDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int RatingCount { get; set; }
        public double Rating { get; set; }
        public IFormFile Image { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public bool? IsActive { get; set; }
        public int CategoryId { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<SelectListItem>? Categories { get; set; }
    }
}
