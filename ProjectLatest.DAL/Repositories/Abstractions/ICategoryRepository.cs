using ProjectLatest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectLatest.DAL.Repositories.Abstractions;

public interface ICategoryRepository : IRepository<Category>
{
    Task<ICollection<SelectListItem>> SelectCategoryAsync();
}
