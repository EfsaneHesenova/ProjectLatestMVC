using Microsoft.EntityFrameworkCore;
using ProjectLatest.Core.Models;
using ProjectLatest.DAL.Contexts;
using ProjectLatest.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectLatest.DAL.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<SelectListItem>> SelectCategoryAsync()
        {
            return await _context.Categories.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Title
            }).ToListAsync();
        }
    }
}
