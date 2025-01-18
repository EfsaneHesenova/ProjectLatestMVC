using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProjectLatest.BL.DTOs.ExploreItemDtos;
using ProjectLatest.BL.ExternalService.Abstractions;
using ProjectLatest.BL.Services.Abstractions;
using ProjectLatest.Core.Models;
using ProjectLatest.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProjectLatest.BL.Services.Implementations
{
    public class ExploreItemService : IExploreItemService
    {
        private readonly IExploreItemRepository _exploreItemRepo;
        private readonly IMapper _mapper;
        private readonly IFileUploadService _uploadService;
        IWebHostEnvironment _envHost;


        public ExploreItemService(IExploreItemRepository exploreItemRepo, IMapper mapper, IFileUploadService uploadService, IWebHostEnvironment envHost)
        {
            _exploreItemRepo = exploreItemRepo;
            _mapper = mapper;
            _uploadService = uploadService;
            _envHost = envHost;
        }

        public async Task<bool> CreateExploreItemAsync(ExploreItemPostDto exploreItemPostDto)
        {
            ExploreItem exploreItem = _mapper.Map<ExploreItem>(exploreItemPostDto);
            exploreItem.ImageUrl = await _uploadService.FileUploadAsync(exploreItemPostDto.Image, _envHost.WebRootPath, new[] { ".png", ".jpg", ".webp", ".jpeg" });
            exploreItem.CreatedAt = DateTime.Now;
            await _exploreItemRepo.CreateAsync(exploreItem);
            int rows = await _exploreItemRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
            return true;
        }

        public async Task<bool> DeleteExploreItemAsync(int id)
        {
            if (!await _exploreItemRepo.IsExist(id))
            {
                throw new Exception("Something went wrong");
            }
            ExploreItem exploreItem = await _exploreItemRepo.GetByIdAsync(id);
            if (exploreItem is null)
            {
                throw new Exception("Something went wrong");
            }
            _uploadService.DeleteFile(exploreItem.ImageUrl, _envHost.WebRootPath);

            _exploreItemRepo.Delete(exploreItem);
            int rows = await _exploreItemRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
            return true;
        }

        public async Task<ICollection<ExploreItem>> GetAllExploreItemAsync()
        {
            ICollection<ExploreItem> exploreItems = await _exploreItemRepo.GetAllAsync();
            return exploreItems;
        }

        public async Task<ExploreItem> GetByIdExploreItemAsync(int id)
        {
            if (!await _exploreItemRepo.IsExist(id))
            {
                throw new Exception("Something went wrong");
            }
            ExploreItem exploreItem = await _exploreItemRepo.GetByIdAsync(id);
            if (exploreItem is null)
            {
                throw new Exception("Something went wrong");
            }
            return exploreItem;
        }

        public async Task<bool> RestoreExploreItemAsync(int id)
        {
            if (!await _exploreItemRepo.IsExist(id))
            {
                throw new Exception("Something went wrong");
            }
            ExploreItem exploreItem = await _exploreItemRepo.GetSingleByCondition(x => x.Id == id && x.IsDeleted);
            exploreItem.IsDeleted = false;
            _exploreItemRepo.Update(exploreItem);
            int rows = await _exploreItemRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
            return true;
        }

        public async Task<bool> SoftDeleteExploreItemAsync(int id)
        {
            if (!await _exploreItemRepo.IsExist(id))
            {
                throw new Exception("Something went wrong");
            }
            ExploreItem exploreItem = await _exploreItemRepo.GetSingleByCondition(x => x.Id == id && !x.IsDeleted);
            exploreItem.IsDeleted = true;
            _exploreItemRepo.Update(exploreItem);
            int rows = await _exploreItemRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
            return true;
        }

        public async Task UpdateExploreItemAsync(ExploreItemPutDto exploreItemPutDto)
        {
            if(!await _exploreItemRepo.IsExist(exploreItemPutDto.Id))
            {
                throw new Exception("Something went wrong");
            }
            ExploreItem exploreItem = _mapper.Map<ExploreItem>(exploreItemPutDto);
            exploreItem.ImageUrl = await _uploadService.FileUploadAsync(exploreItemPutDto.Image, _envHost.WebRootPath, new[] { ".png", ".jpg", ".webp", ".jpeg" });
            _exploreItemRepo.Update(exploreItem);

            int rows = await _exploreItemRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}
