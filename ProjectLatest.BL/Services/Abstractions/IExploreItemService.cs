using ProjectLatest.BL.DTOs.ExploreItemDtos;
using ProjectLatest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLatest.BL.Services.Abstractions
{
    public interface IExploreItemService
    {
        Task<bool> CreateExploreItemAsync(ExploreItemPostDto exploreItemPostDto);
        Task<ICollection<ExploreItem>> GetAllExploreItemAsync();
        Task UpdateExploreItemAsync(ExploreItemPutDto exploreItemPutDto);
        Task<bool> DeleteExploreItemAsync(int id);
        Task<ExploreItem> GetByIdExploreItemAsync(int id);
        Task<bool> RestoreExploreItemAsync(int id);
        Task<bool> SoftDeleteExploreItemAsync(int id);

    }
}
