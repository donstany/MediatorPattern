using BLL.Requests.ValuesRequest;
using BLL.Values.Commands.DeleteValueCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication2.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ValuesController : Controller
    {
        private readonly IMediator _mediatr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediatr"></param>
        public ValuesController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        /// <summary>
        /// Get value by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ValueRequestResponse</returns>
        [HttpGet]
        public async Task<ValueResponse> Get(ValueRequest request)
        {
            return await _mediatr.Send(request);
        }

        /// <summary>
        /// Delete a value by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> Delete(DeleteValueCommand request)
        {
            return await _mediatr.Send(request);
        }
    }
}