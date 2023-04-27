using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace CallMePhonyApp.Data
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        // </inheritdoc>
        public async Task<T> HttpGetAsync<T>(string url, string bearerToken = null)
        {
            if (bearerToken != null)
            {
                SetBearer(bearerToken);
            }
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            return await DeserializeJson<T>(response);
        }

        // </inheritdoc>
        public async Task<T> HttpPostAsync<T>(string url, object model, string bearerToken = null)
        {
            if (bearerToken != null)
            {
                SetBearer(bearerToken);
            }
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, model);
            return await DeserializeJson<T>(response);
        }

        // </inheritdoc>
        public async Task<T> HttpPutAsync<T>(string url, object model, string bearerToken = null)
        {
            if (bearerToken != null)
            {
                SetBearer(bearerToken);
            }
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(url, model);
            return await DeserializeJson<T>(response);
        }

        // </inheritdoc>
        public async Task<bool> HttpDeleteAsync(string url, string bearerToken = null)
        {
            if (bearerToken != null)
            {
                SetBearer(bearerToken);
            }
            HttpResponseMessage responseMessage = await _httpClient.DeleteAsync(url);
            responseMessage.EnsureSuccessStatusCode();
            return responseMessage.IsSuccessStatusCode;
        }

        private void SetBearer(string bearerToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        }

        private async Task<T> DeserializeJson<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var responseText = await response.Content.ReadAsStringAsync();
            T jsonResponse = JsonConvert.DeserializeObject<T>(responseText);
            return jsonResponse;
        }

    }
}
