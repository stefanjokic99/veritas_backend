using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using veritas_backend.DTOs.Core;

namespace veritas_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null)
            {
                return NotFound();
            }
            if (result.IsSuccess && result.Value != null)
            {
                return Ok(result.Value);
            }
            if (result.IsSuccess && result.Value == null)
            {
                return NotFound();
            }
            return BadRequest(result.Error);
        }

        protected async Task<ActionResult> HandleResult(HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new Exception(await responseMessage.Content.ReadAsStringAsync());
            }

            if (responseMessage == null || responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }

            var result = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.IsSuccessStatusCode && result != null)
            {
                return Ok(result);
            }
            if (responseMessage.IsSuccessStatusCode && result == null)
            {
                return NotFound();
            }

            return BadRequest(result);
        }
    }
}