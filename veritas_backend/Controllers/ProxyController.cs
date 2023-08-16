using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Web;
using veritas_backend.ActionFilterAttributes;

namespace veritas_backend.Controllers
{
    [ValidatePluginExists]
    public class ProxyController : BaseProxyApiController
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProxyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{pluginName}/{url}")]
        public async Task<IActionResult> Get(string pluginName, string url, [FromQuery] Dictionary<string, string> queryParams)
        {   
            var httpClient = _httpClientFactory.CreateClient($"{pluginName}");
            var urlDecoded = HttpUtility.UrlDecode(url);

            var queryString = string.Join("&", queryParams.Select(kv => $"{kv.Key}={kv.Value}"));
            var finalUrl = $"{urlDecoded}?{queryString}";

            return await HandleResult(await httpClient.GetAsync(finalUrl));
        }


        [HttpPost("{pluginName}/{url}")]
        public async Task<IActionResult> Post(string pluginName, string url, [FromBody] object dataObj)
        {
            var httpClient = _httpClientFactory.CreateClient($"{pluginName}");
            var urlDecoded= HttpUtility.UrlDecode(url);

            var requestBody = new
            {
                Data = dataObj,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            var json = JsonSerializer.Serialize(requestBody);
            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return await HandleResult(await httpClient.PostAsync(urlDecoded, content));
        }

        [HttpPut("{pluginName}/{url}")]
        public async Task<IActionResult> Patch(string pluginName, string url, [FromBody] object dataObj)
        {
            var httpClient = _httpClientFactory.CreateClient($"{pluginName}");
            var urlDecoded = HttpUtility.UrlDecode(url);

            var requestBody = new
            {
                Data = dataObj,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            var json = JsonSerializer.Serialize(requestBody);
            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return await HandleResult(await httpClient.PatchAsync(urlDecoded, content));
        }

        [HttpDelete("{pluginName}/{url}")]
        public async Task<IActionResult> Delete(string pluginName, string url, [FromBody] object identificationParams)
        {
            var httpClient = _httpClientFactory.CreateClient($"{pluginName}");
            var urlDecoded = HttpUtility.UrlDecode(url);

            var requestBody = new
            {
                Data = identificationParams,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            var json = JsonSerializer.Serialize(requestBody);

            var request = new HttpRequestMessage(HttpMethod.Delete, urlDecoded);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(json, Encoding.UTF8, "application/json"); ;

            return await HandleResult(await httpClient.SendAsync(request)); 
        }

    }

}
