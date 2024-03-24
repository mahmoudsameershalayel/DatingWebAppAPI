using App.API.Infrastructure.Services.ApplicationUserService;
using App.API.Infrastructure.Services.TokenService;
using App.Core.APIDto.ApplicationUserDto;
using App.Data.DbEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DatingWebAppAPI.Controllers
{
    public class AccountController : BaseController
    {

        private readonly IApplicationUserService _applicationUserService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AccountController(IApplicationUserService applicationUserService , UserManager<ApplicationUser> userManager , ITokenService tokenService)
        {
            _applicationUserService = applicationUserService;
            _userManager = userManager;
            _tokenService = tokenService;
        }
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> Register(CreateApplicationUserDto dto)
        {
            if (ModelState.IsValid) {
                if (await _applicationUserService.IsExist(dto.UserName))
                {
                    return BadRequest("The username is taken");
                }
                var user = await _applicationUserService.Create(dto);
                await _applicationUserService.CreatePublicUser(user.Id);
                return Ok(new { message = "Add Successfully", user });
            }
            return BadRequest();
           
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(LoginDto dto) {

            var item = _applicationUserService.GetUserByUsername(dto.Username).Result;
            if (item == null) {
                return Unauthorized("Invalid Username");
            }
            var result = await _userManager.CheckPasswordAsync(item, dto.Password);
            if (!result) return Unauthorized("Invalid Username OR Password");
            return new UserDto
            {
                Username = item.UserName,
                Token = await _tokenService.CreateToken(item),
                Gender = item.Gender
            };
        }
    }
}
