using bank;
using Models;
using System.Net.Http;
using System.Text.Json;


namespace Services
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient) {
            this._httpClient = httpClient;
        }

        public async Task<TResponse> SendGetRequest<TRequest, TResponse>(string endPointUrl)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<TResponse>(endPointUrl);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
            return default;
        }

        public async Task<TResponse> PostDataRequest<TRequest, TResponse>(string endpoint, TRequest data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(endpoint, data);
                
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }

            return default;  
        }

        public async Task<TResponse> PutDataRequest <TRequest, TResponse>(string endpoint, TRequest data)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(endpoint, data);
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
            return default;
        }
    }
}
