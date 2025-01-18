using Microsoft.AspNetCore.Mvc;
using ProjectLatest.BL.Services.Abstractions;

namespace ProjectLatest.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
