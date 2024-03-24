using App.API.Infrastructure.Services.ApplicationUserService;
using App.API.Infrastructure.Services.PhotoService;
using App.Core.APIDto.ApplicationUserDto;
using App.Core.APIViewModel;
using App.Data;
using App.Data.DbEntities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace DatingWebAppAPI.Controllers
{
    public class ApplicationUserController : BaseController
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IPhotoService _photoService;
        public ApplicationUserController(IApplicationUserService applicationUserService , IPhotoService photoService)
        {
            _applicationUserService = applicationUserService;
            _photoService = photoService;
        }
        [HttpGet]
        public async Task<ActionResult<List<PublicUserViewModel>>> GetAll(string? key)
        {
            return await _applicationUserService.GetAll(key);
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<PublicUserViewModel>> GetUser(string username)
        {
            return await _applicationUserService.GetPublicUserByUsername(username);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateApplicationUserDto dto)
        {
            if (ModelState.IsValid)
            {
                if (await _applicationUserService.IsExist(dto.UserName))
                {
                    return BadRequest("The username is taken");
                }
                var user = await _applicationUserService.Create(dto);
                await _applicationUserService.CreatePublicUser(user.Id);
                return NoContent();
            }
            return BadRequest(new { message = "The model state in invalid!!" });

        }
        [HttpPost("{userName}")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImage(string userName) {
           var result = await _photoService.uploadPhoto(userName, Request);
            if (result == true) {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut("{username}")]
        public async Task<ActionResult> Update(string username, UpdateApplicationUserDto dto)
        {
            await _applicationUserService.Update(username, dto);
            return NoContent();
        }
        [HttpGet]
        public ActionResult<string> getUsername()
        {
            return _applicationUserService.GetCurrentUserName();
        }

    }
}

