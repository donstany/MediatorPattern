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

        /// <summary>
        /// Index endpoint
        /// </summary>
        /// <returns>Ok</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }

        /// <summary>
        /// Get value by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ValueRequestResponse</returns>
        [HttpGet("value")]
        public ActionResult Get(ValueRequest request)
        {
            var response = _mediatr.Send(request);
            return Ok(response.Result);
        }
    }
}