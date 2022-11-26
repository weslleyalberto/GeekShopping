using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public  static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage responde)
        {
            if (!responde.IsSuccessStatusCode)
                throw new ArgumentException($"Algo aconteceu de errado: {responde.ReasonPhrase}");
            var dataAsString  = await responde.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString  = JsonSerializer.Serialize(data);
            var content  = new StringContent(dataAsString);
            //var tipoConteudo =new MediaTypeHeaderValue("application/json");
            content.Headers.ContentType = contentType;
            return httpClient.PostAsync(url,content);
        }
        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            //var tipoConteudo =new MediaTypeHeaderValue("application/json");
            content.Headers.ContentType = contentType;
            return httpClient.PutAsync(url, content);
        }

    }
}
