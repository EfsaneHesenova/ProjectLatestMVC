using AutoMapper;
using ProjectLatest.BL.DTOs.CategoryDtos;
using ProjectLatest.BL.DTOs.CategoryDtos;
using ProjectLatest.BL.Services.Abstractions;
using ProjectLatest.Core.Models;
using ProjectLatest.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectLatest.BL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<bool> CreateCategoryAsync(CategoryPostDto categoryPostDto)
        {
            Category category = _mapper.Map<Category>(categoryPostDto);
            await _categoryRepo.CreateAsync(category);
            int rows = await _categoryRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
            return true;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            if (!await _categoryRepo.IsExist(id))
            {
                throw new Exception("Something went wrong");
            }
            Category category = await _categoryRepo.GetByIdAsync(id);
            if (category is null)
            {
                throw new Exception("Something went wrong");
            }
            _categoryRepo.Delete(category);
        }

        public async Task<ICollection<Category>> GetAllCategoryAsync()
        {
            ICollection<Category> categorys = await _categoryRepo.GetAllAsync();
            return categorys;
        }

        public async Task<bool> GetByIdCategoryAsync(int id)
        {
            if (!await _categoryRepo.IsExist(id))
            {
                throw new Exception("Something went wrong");
            }
            Category category = await _categoryRepo.GetByIdAsync(id);
            if (category is null)
            {
                throw new Exception("Something went wrong");
            }
            return true;
        }

        public async Task<bool> RestoreCategoryAsync(int id)
        {
            if (!await _categoryRepo.IsExist(id))
            {
                throw new Exception("Something went wrong");
            }
            Category category = await _categoryRepo.GetSingleByCondition(x => x.Id == id && x.IsDeleted);
            category.IsDeleted = false;
            _categoryRepo.Update(category);
            int rows = await _categoryRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
            return true;
        }

        public async Task<ICollection<SelectListItem>> SelectAllCategoryAsync()
        {
            return await _categoryRepo.SelectCategoryAsync();
        }

        public async Task<bool> SoftDeleteCategoryAsync(int id)
        {
            if (!await _categoryRepo.IsExist(id))
            {
                throw new Exception("Something went wrong");
            }
            Category category = await _categoryRepo.GetSingleByCondition(x => x.Id == id && !x.IsDeleted);
            category.IsDeleted = true;
            _categoryRepo.Update(category);
            int rows = await _categoryRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
            return true;
        }

        public async Task UpdateCategoryAsync(CategoryPutDto categoryPutDto)
        {
            if (!await _categoryRepo.IsExist(categoryPutDto.Id))
            {
                throw new Exception("Something went wrong");
            }
            Category category = await _categoryRepo.GetByIdAsync(categoryPutDto.Id);
            if (category is null)
            {
                throw new Exception("Something went wrong");
            }
            _categoryRepo.Update(category);

            int rows = await _categoryRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}
