using App.Core.APIDto.ApplicationUserDto;
using App.Core.APIViewModel;
using App.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.API.Infrastructure.Services.ApplicationUserService
{
    public interface IApplicationUserService
    {
        public Task<List<ApplicationUserViewModel>> GetAll(string? key);
        public Task<CreateApplicationUserDto> GetById(string id);
        public Task<ApplicationUser> GetUserByUsername(string username);
        public Task<UpdateApplicationUserDto> GetByIdForEdit(string id);
        public Task<ApplicationUser> Create(CreateApplicationUserDto dto);
        public Task<int> CreatePublicUser(string userId);

        public Task<UpdateApplicationUserDto> Update(UpdateApplicationUserDto dto);
        public Task<bool> IsExist(string userName);
        public Task<string> Delete(string id);
    }
}
