using App.Core.APIDto.ApplicationUserDto;
using App.Core.APIViewModel;
using App.Data.DbEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.API.Infrastructure.Services.ApplicationUserService
{
    public interface IApplicationUserService
    {
        public Task<List<PublicUserViewModel>> GetAll(string? key);
        public Task<PublicUserViewModel> GetPublicUserByUsername(string username);
        public Task<ApplicationUser> GetUserByUsername(string username);
        public string GetCurrentUserName();
        public Task<ApplicationUser> Create(CreateApplicationUserDto dto);
        public Task<int> CreatePublicUser(string userId);
        public Task<UpdateApplicationUserDto> Update(string id ,UpdateApplicationUserDto dto);
        public Task<bool> UploadImageProfile(IFormFile Image);
        public Task<bool> IsExist(string userName);
        public Task<string> Delete(string id);
    }
}
