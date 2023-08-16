using Microsoft.AspNetCore.Mvc;
using System.Net;
using veritas_backend.DTOs.Core;

namespace veritas_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseProxyApiController : ControllerBase
    {

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