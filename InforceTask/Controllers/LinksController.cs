﻿using InforceTask.DAL;
using InforceTask.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InforceTask.Controllers
{
    [AllowAnonymous]
    public class LinksController : Controller
    {
        private readonly LinksDbContext _linksDbContext;

        public LinksController(LinksDbContext baseContext)
        {
            _linksDbContext = baseContext;
        }



        [HttpGet]
        public async Task<IActionResult> Links() {
            var links = await _linksDbContext.Links.ToListAsync();

            var Model = new AddLinkModel { Links = links };
            
            return View(Model);
        }
        [HttpPost]
        public async Task<IActionResult> Links(AddLinkModel model)
        {

            var links = await _linksDbContext.Links.ToListAsync();
            var Model = new AddLinkModel { Links = links };

            if (links.Any(i => i.LongLink.Equals(model.LongLink)))
            {
                Model.ErrorMessage = "Such Url exists";
                return View(Model);
            }
            if (!model.LongLink.Contains("https://"))
            {
                Model.ErrorMessage = "Url is not valid";
                return View(Model);
            }
            var id = Guid.NewGuid();
            var link = new Link
            {
                ID = id,
                LongLink = model.LongLink,
                ShortLink = "https://localhost:7257/short/" + (id.ToString()).Substring(0, 6),
                CreatedBy = User.Identity.Name,
                CreatedDate = DateTime.Now,
            };

            await _linksDbContext.Links.AddAsync(link);
            await _linksDbContext.SaveChangesAsync();
            return RedirectToAction("Links");
        }

        [HttpGet]
        public async Task<IActionResult> Redirector(string id)
        {
            var links = await _linksDbContext.Links.ToListAsync();

            var point = links.Where(i => i.ID.ToString().Substring(0, 6).Equals(id)).First();

            return Redirect(point.LongLink);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var linkToDelete =  _linksDbContext.Links.Where(i => i.ID.ToString().Equals(id)).First();
            _linksDbContext.Links.Remove(linkToDelete);
            await _linksDbContext.SaveChangesAsync();
            return RedirectToAction("Links");
        }

        [HttpGet]
        public async Task<IActionResult> Info(string id)
        {
            var linkToDelete = _linksDbContext.Links.Where(i => i.ID.ToString().Equals(id)).First();
            return View(linkToDelete);
            
        }
    }
    
}