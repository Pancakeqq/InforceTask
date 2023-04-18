using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InforceTask.DAL;
using InforceTask.Models;
using InforceTask.Controllers;
using Microsoft.AspNetCore.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tests.Controlers
{
    
    public class LinksControllerTests
    {
        private LinksDbContext _linksDbContext;
        private IHttpContextAccessor _httpContextAccessor;
        private LinksController _LinksController;

        public LinksControllerTests()
        {
            var options = new DbContextOptionsBuilder<LinksDbContext>().Options;

            _linksDbContext = A.Fake<LinksDbContext>(x => x.WithArgumentsForConstructor(() =>new LinksDbContext(options)));
            _httpContextAccessor = A.Fake<HttpContextAccessor>();

            _LinksController = new LinksController(_linksDbContext);
        }

        [Fact]
        public async void LinksController_LinksGet_ReturnsSuccess()
        {
            var links = A.Fake<IEnumerable<Link>>();
            //A.CallTo(() =>  _linksDbContext.Links.ToList()).Returns(links);

            var result = _LinksController.Links();

            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public async void LinksController_LinksPost_ReturnsSuccess()
        {
            var links = A.Fake<IEnumerable<Link>>();
            //A.CallTo(() =>  _linksDbContext.Links.ToList()).Returns(links);
            var model = A.Fake<AddLinkModel>();
            var result = _LinksController.Links(model);

            result.Should().BeOfType<Task<IActionResult>>();
        }
        [Fact]
        public async void LinksController_Redirect_ReturnsSuccess()
        {
            var links = A.Fake<IEnumerable<Link>>();
            //A.CallTo(() =>  _linksDbContext.Links.ToList()).Returns(links);
            var id = "test";
            var result = _LinksController.Redirector(id);

            result.Should().BeOfType<Task<RedirectResult>>();
        }
        [Fact]
        public async void LinksController_Delete_ReturnsSuccess()
        {
            var model = A.Fake<AddLinkModel>();
            var result = _LinksController.Links(model);

            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public async void LinksController_Info_ReturnsSuccess()
        {
            var model = A.Fake<AddLinkModel>();
            var result = _LinksController.Links(model);

            result.Should().BeOfType<Task<IActionResult>>();
        }

    }
}
