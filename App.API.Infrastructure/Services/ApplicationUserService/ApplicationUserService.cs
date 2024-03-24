using App.Core.APIDto.ApplicationUserDto;
using App.Core.APIViewModel;
using App.Data;
using App.Data.DbEntities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
        private readonly IHttpContextAccessor _contextAccessor;


        public ApplicationUserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<PublicUserViewModel>> GetAll(string? key)
        {
            var items = await _context.Users.Where(x => string.IsNullOrEmpty(key) || x.ApplicationUser.UserName.Contains(key)).Include(x => x.ApplicationUser).ToListAsync();
            var userViewModels = _mapper.Map<List<PublicUserViewModel>>(items);
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

        public async Task<ApplicationUser> GetUserByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<PublicUserViewModel> GetPublicUserByUsername(string username)
        {
            var item = await _context.Users.Where(x => x.ApplicationUser.IsDeleted == false && x.ApplicationUser.UserName == username).Include(x => x.ApplicationUser).FirstOrDefaultAsync();
            return _mapper.Map<PublicUserViewModel>(item);
        }

        public string GetCurrentUserName()
        {
            var currentUser = _contextAccessor.HttpContext.User;
            var userName = currentUser.Identity.Name;
            return userName;

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
            _User.Gender = dto.Gender;
            _User.ImageName = dto.ImageName;
            _User.City = dto.City;
            _User.Country = dto.Country;
            _User.Introduction = dto.Introduction;
            _User.Interests = dto.Interests;
            _User.LookingFor = dto.LookingFor;
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

        public async Task<UpdateApplicationUserDto> Update(string username , UpdateApplicationUserDto dto)
        {
            var item = await _context.Users.Where(x => x.ApplicationUser.IsDeleted == false && x.ApplicationUser.UserName == username).Include(x => x.ApplicationUser).FirstOrDefaultAsync();
            if (item != null)
            {
                var imageName = item.ApplicationUser.ImageName;
                var _updatedItem = _mapper.Map(dto, item);
                _updatedItem.ApplicationUser.ImageName = imageName;
                _context.Users.Update(_updatedItem);
                await _context.SaveChangesAsync();
            }
            return dto;
        }
        public async Task<bool> UploadImageProfile(IFormFile Image) {
            return true;
        }

    }
}
