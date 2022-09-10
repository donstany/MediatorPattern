using BLL.Requests.ValuesRequest;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediatr;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMediator mediatr, ILogger<HomeController> logger)
        {
            _mediatr = mediatr;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("value")]
        public ActionResult Get(ValueRequest request)
        {
            var response = _mediatr.Send(request);
            return Ok(response.Result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}