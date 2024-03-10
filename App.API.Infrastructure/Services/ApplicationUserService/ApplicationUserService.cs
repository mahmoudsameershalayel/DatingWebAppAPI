using App.Core.APIDto.ApplicationUserDto;
using App.Core.APIViewModel;
using App.Data;
using App.Data.DbEntities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.API.Infrastructure.Services.ApplicationUserService
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public ApplicationUserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<ApplicationUser> Create(CreateApplicationUserDto dto)
        {
            ApplicationUser _User = new ApplicationUser();
            _User.Created_At = DateTime.Now;
            _User.FullName =  dto.FullName;
            _User.IsActive = true;
            _User.IsDeleted = false;
            _User.Email = dto.Email;
            _User.UserName = dto.UserName.ToLower();
            _User.Phone = dto.Phone;
            _User.BirthDate = dto.BirthDate;                       
            _User.UserType = (Core.Enums.UserType)1;
            _User.Gender = (Core.Enums.Gender)dto.Gender;
            await _userManager.CreateAsync(_User, dto.Password);
            await _userManager.AddToRoleAsync(_User, "publicUser");
            return _User;
        }

        public async Task<int> CreatePublicUser(string userId)
        {
            var item = await _userManager.FindByIdAsync(userId);
            var user = new User
            {
                ApplicationUser = item,
                ApplicationUserId = userId,
            };
            await _context.AddAsync(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<string> Delete(string id)
        {
            var item = await GetUserById(id);
            await _userManager.DeleteAsync(item);
            return id;
        }

        public async Task<List<ApplicationUserViewModel>> GetAll(string? key)
        {
            var items = await _context.Users.Include(x => x.ApplicationUser).ToListAsync();
            var userViewModels = new List<ApplicationUserViewModel>();
            foreach (var user in items)
            {
                var userViewModel = new ApplicationUserViewModel
                {
                    FullName = user.ApplicationUser.FullName,
                    Phone = user.ApplicationUser.Phone,
                    BirthDate = user.ApplicationUser.BirthDate,
                    IsActive = user.ApplicationUser.IsActive,
                    Gender = user.ApplicationUser.Gender,
                };
                userViewModels.Add(userViewModel);
            }
            return userViewModels;
        }

        public async Task<CreateApplicationUserDto> GetById(int id)
        {
            var item = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            var dto = _mapper.Map<CreateApplicationUserDto>(item);
            return dto;
        }

        public async Task<UpdateApplicationUserDto> GetByIdForEdit(int id)
        {
            var item = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            var dto = _mapper.Map<UpdateApplicationUserDto>(item);
            return dto;
        }

        public Task<UpdateApplicationUserDto> GetByIdForEdit(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<ApplicationUser> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsExist(string userName)
        {
            return await _context.Users.AnyAsync(x => x.ApplicationUser.UserName == userName.ToLower());
        }

        public async Task<UpdateApplicationUserDto> Update(UpdateApplicationUserDto dto)
        {
            var user = await GetUserById(dto.Id);
            var item = _mapper.Map(dto, user);
            await _userManager.UpdateAsync(user);
            return dto;
        }

        public Task<CreateApplicationUserDto> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetUserByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }
    }
}
