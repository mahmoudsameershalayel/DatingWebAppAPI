using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.API.Infrastructure.Services.PhotoService
{
    public interface IPhotoService
    {
        public Task<bool> uploadPhoto(string userName , HttpRequest request);
    }
}
