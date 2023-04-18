using InforceTask.DAL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InforceTask.Controllers
{
    [AllowAnonymous]
    public class ShortController : Controller
    {
        private readonly LinksDbContext _linksDbContext;

        public ShortController(LinksDbContext baseContext)
        {
            _linksDbContext = baseContext;
        }

        [HttpGet]
        [Route ("short/{id?}")]
        public async Task<IActionResult> Url(string id)
        {
            var links = await _linksDbContext.Links.ToListAsync();

            var point = links.Where(i => i.ID.ToString().Substring(0, 6).Equals(id)).First();

            return Redirect(point.LongLink);
        }
    }
}
