using ProjectLatest.BL.DTOs.AccountsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLatest.BL.Services.Abstractions
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(CreateDto createDto);
        Task<bool> LoginAsync(LoginDto loginDto);
        Task LogoutAsync();
    }
}
