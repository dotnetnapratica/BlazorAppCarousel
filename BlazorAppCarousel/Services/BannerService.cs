using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BlazorAppCarousel.Services
{
    public class BannerService : IBannerService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public BannerService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<List<string>> GetBanners()
        {
            using(var httpClient = httpClientFactory.CreateClient())
            {
                var jsonString = await httpClient.GetStringAsync("https://raw.githubusercontent.com/dotnetnapratica/BlazorAppCarousel/master/banners.json");

                var itemsString = JsonNode.Parse(jsonString).AsObject()["items"];

                return JsonSerializer.Deserialize<List<string>>(itemsString);
            }
        }
    }
}
