using System.Net.Http;

namespace AnimeNewsletter.Services
{
    public class N8NService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;


        public N8NService(IConfiguration config, HttpClient httpClient)
        {
            _config = config;
            _httpClient = httpClient;
        }

        public async Task<string> TriggerGet(string urlToSend)
        {
            string n8nWebhookUrl = $"{_config["ExternalServices:N8NServerUrl"]}{urlToSend}";

            HttpResponseMessage response = await _httpClient.GetAsync(n8nWebhookUrl);

            if (response.IsSuccessStatusCode)
            {
                // Extract the raw JSON string directly from the response content
                string rawJsonContent = await response.Content.ReadAsStringAsync();

                return rawJsonContent;
            }

            throw new Exception($"Failed to trigger n8n workflow. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}");
        }
    }
}
