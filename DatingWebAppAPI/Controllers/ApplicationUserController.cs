using App.API.Infrastructure.Services.ApplicationUserService;
using App.Core.APIDto.ApplicationUserDto;
using App.Core.APIViewModel;
using App.Data;
using App.Data.DbEntities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingWebAppAPI.Controllers
{
    
    public class ApplicationUserController : BaseController
    {
        private readonly IApplicationUserService _applicationUserService;
        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ApplicationUserViewModel>>> GetAll(string? key)
        {
            return await _applicationUserService.GetAll(key);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromForm] CreateApplicationUserDto dto)
        {
            if (await _applicationUserService.IsExist(dto.UserName)) {
                return BadRequest("The username is taken");
            }
            var user = await _applicationUserService.Create(dto);
            await _applicationUserService.CreatePublicUser(user.Id);
            return Ok(new { message = "Add Successfully" });
        }
       
    }
}

