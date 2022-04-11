using CsvProcessorApi.Models;
using CsvProcessorApi.Models.Responses;
using Microsoft.AspNetCore.Identity;

namespace CsvProcessorApi.Services
{
    public interface IAccountService
    {
        Task<AuthResponse> UserValidate(LoginModel login);
        Task<AuthResponse> UserCreate(LoginModel login);
        Task<IdentityUser> AdminRolCreate(string userName);
        Task<IdentityUser> AdminRolRemove(string userName);
    }
}
