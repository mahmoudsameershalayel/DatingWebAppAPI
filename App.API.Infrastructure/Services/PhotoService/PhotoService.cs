using App.API.Infrastructure.Services.ApplicationUserService;
using App.Data;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace App.API.Infrastructure.Services.PhotoService
{
    public class PhotoService : IPhotoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IApplicationUserService _userService;
        public PhotoService(IApplicationUserService userService , ApplicationDbContext context)
        {

            _userService = userService;
            _context = context;

        }
        public async Task<bool> uploadPhoto(string userName , HttpRequest request)
        {
            try
            {
                var file = request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var item = await _userService.GetUserByUsername(userName);
                    if (item != null)
                    {
                        item.ImageName = fullPath;
                        await _context.SaveChangesAsync();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
