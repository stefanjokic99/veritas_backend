using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using veritas_backend.ActionFilterAttributes;

namespace veritas_backend.Controllers
{
    [ValidatePluginExists]
    public class ProxyController : BaseApiController
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProxyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [AllowAnonymous]
        [HttpGet("{pluginName}/{url}")]
        public async Task<IActionResult> Get(string pluginName, string url)
        {   
            var httpClient = _httpClientFactory.CreateClient($"{pluginName}");

            return await HandleResult(await httpClient.GetAsync(url));
        }


        [AllowAnonymous]
        [HttpPost("{pluginName}/{url}")]
        public async Task<IActionResult> Post(string pluginName, string url, [FromBody] object data)
        {
            var httpClient = _httpClientFactory.CreateClient($"{pluginName}");
            var json = JsonSerializer.Serialize(data);
            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return await HandleResult(await httpClient.PostAsync(url, content));
        }

        [AllowAnonymous]
        [HttpPut("{pluginName}/{url}")]
        public async Task<IActionResult> Patch(string pluginName, string url, [FromBody] object data)
        {
            var httpClient = _httpClientFactory.CreateClient($"{pluginName}");
            var json = JsonSerializer.Serialize(data);
            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return await HandleResult(await httpClient.PatchAsync(url, content));
        }

        [AllowAnonymous]
        [HttpDelete("{pluginName}/{url}")]
        public async Task<IActionResult> SendMessage(string pluginName, string url)
        {
            var httpClient = _httpClientFactory.CreateClient($"{pluginName}");

            return await HandleResult(await httpClient.DeleteAsync(url)); 
        }

    }

}
