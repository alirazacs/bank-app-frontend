using bank;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;


namespace Services
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;
        private ToastService toastService;

        public HttpClientService(HttpClient httpClient, ToastService toastService)
        {
            this._httpClient = httpClient;
            this.toastService = toastService;
        }

        public async Task<TResponse> SendGetRequest<TResponse>(string endPointUrl, Type responseType) where TResponse : class
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, endPointUrl);
                request.Headers.Add("Accept", "application/json");

                toastService.Notify(new(ToastType.Success, $"Employee details saved successfully."));
                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    TResponse responseObject = JsonConvert.DeserializeObject(responseBody, responseType) as TResponse;
                    return responseObject;
                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }

            return default;
        }



        public async Task<TResponse> PostDataRequest<TRequest, TResponse>(string endPointUrl, TRequest data, Type responseType) where TResponse : class
        {
            try
            {
                string jsonRequestData = JsonConvert.SerializeObject(data);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, endPointUrl);
                request.Headers.Add("Accept", "application/json");
                request.Content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    TResponse responseObject = JsonConvert.DeserializeObject(responseBody, responseType) as TResponse;
                    return responseObject;
                }
                else
                {
                    Console.WriteLine($"Status code : {response.Content}");
                }
                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }

            return default;
        }

        public async Task<TResponse> PutDataRequest<TRequest, TResponse>(string endPointUrl, TRequest data, Type responseType) where TRequest : class
            where TResponse : class
        {
            try
            {
                string jsonRequestData = JsonConvert.SerializeObject(data);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, endPointUrl);
                request.Headers.Add("Accept", "application/json");
                request.Content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    TResponse responseObject = JsonConvert.DeserializeObject(responseBody, responseType) as TResponse;
                    return responseObject;
                }
                else
                {

                    Console.WriteLine($"Status code : {response.Content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
            return default;
        }

    }
}
