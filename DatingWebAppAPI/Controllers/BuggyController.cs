using App.Data;
using App.Data.DbEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingWebAppAPI.Controllers
{
    public class BuggyController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public BuggyController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet]
        public ActionResult<string> GetSecret() {
            return "secret text";
        }
        [HttpGet]
        public ActionResult<string> GetNotFound() {
            var result = _context.Users.Find(-1);
            if (result == null) return NotFound();
            return Ok(result);
        }
     
        [HttpGet]
        public ActionResult<string> GetBadRequest() {
            return BadRequest("This was not a good request");
        }
    }

}
