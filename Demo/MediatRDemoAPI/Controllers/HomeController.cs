using BLL.Requests.ValuesRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}