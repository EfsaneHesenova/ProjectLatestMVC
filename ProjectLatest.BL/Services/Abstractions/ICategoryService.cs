using ProjectLatest.BL.DTOs.CategoryDtos;
using ProjectLatest.BL.DTOs.ExploreItemDtos;
using ProjectLatest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectLatest.BL.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(CategoryPostDto categoryPostDto);
        Task<ICollection<Category>> GetAllCategoryAsync();
        Task UpdateCategoryAsync(CategoryPutDto categoryPutDto);
        Task DeleteCategoryAsync(int id);
        Task<bool> GetByIdCategoryAsync(int id);
        Task<bool> RestoreCategoryAsync(int id);
        Task<bool> SoftDeleteCategoryAsync(int id);
        Task<ICollection<SelectListItem>> SelectAllCategoryAsync();
    }
}
