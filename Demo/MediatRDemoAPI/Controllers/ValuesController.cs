using BLL.Requests.ValuesRequest;
using BLL.Values.Commands.DeleteValueCommand;
using BLL.Values.Requests.ValuesRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApplication2.Controllers
{
    /// <summary>
    /// Values Controller Class
    /// </summary>
    public class ValuesController : Controller
    {
        private readonly IMediator _mediatr;

        /// <summary>
        /// Values Controller constructor
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
        /// <returns>boolean</returns>
        [HttpDelete]
        public async Task<bool> Delete(DeleteValueCommand request)
        {
            return await _mediatr.Send(request);
        }

        /// <summary>
        /// Getting all values
        /// </summary>
        /// <returns>List of values</returns>
        [HttpGet]
        public async Task<List<Value>> GetAll()
        {
            var request = new ValueListRequest();
            var result = await _mediatr.Send(request);
            return result.Values;
        }
    }
}