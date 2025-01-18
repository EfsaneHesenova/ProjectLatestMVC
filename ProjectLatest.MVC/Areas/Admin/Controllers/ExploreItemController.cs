using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProjectLatest.BL.DTOs.ExploreItemDtos;
using ProjectLatest.BL.Services.Abstractions;
using ProjectLatest.Core.Models;

namespace ProjectLatest.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExploreItemController : Controller
    {
        private readonly IExploreItemService _exploreItemService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ExploreItemController(IExploreItemService exploreItemService, ICategoryService categoryService, IMapper mapper)
        {
            _exploreItemService = exploreItemService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<ExploreItem> exploreItems = await _exploreItemService.GetAllExploreItemAsync();
                return View(exploreItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
              var categories = await _categoryService.SelectAllCategoryAsync();
                ExploreItemPostDto exploreItemPostDto = new ExploreItemPostDto()
                {
                    Categories = categories
                };

                return View(exploreItemPostDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExploreItemPostDto exploreItemPostDto)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.SelectAllCategoryAsync();
                exploreItemPostDto.Categories = categories;
                return View(exploreItemPostDto);
            }
            try
            {
                await _exploreItemService.CreateExploreItemAsync(exploreItemPostDto);
                return RedirectToAction("Index", "ExploreItem", "Admin");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
               ExploreItem? exploreItem = await  _exploreItemService.GetByIdExploreItemAsync(id);
               return View(exploreItem);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                ExploreItem? exploreItem = await _exploreItemService.GetByIdExploreItemAsync(id);
                ExploreItemPutDto exploreItemPutDto = _mapper.Map<ExploreItemPutDto>(exploreItem);
                var categories = await _categoryService.SelectAllCategoryAsync();
                exploreItemPutDto.Categories = categories;
                return View(exploreItemPutDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Update(ExploreItemPutDto exploreItemPutDto)
        {
            if(!ModelState.IsValid)
            {
                var categories = await _categoryService.SelectAllCategoryAsync();
                exploreItemPutDto.Categories = categories;
                return View(exploreItemPutDto);
            }
            try
            {
                await _exploreItemService.UpdateExploreItemAsync(exploreItemPutDto);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
              await  _exploreItemService.DeleteExploreItemAsync(id);
                return RedirectToAction(nameof(Index), "ExploreItem");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        
        [HttpGet]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
               await _exploreItemService.SoftDeleteExploreItemAsync(id);
                return RedirectToAction(nameof(Index), "ExploreItem");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Restore(int id)
        {
            try
            {
               await _exploreItemService.RestoreExploreItemAsync(id);
                return RedirectToAction(nameof(Index), "ExploreItem");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
