public class OpenWeatherService : IOpenWeatherService
    {
        private readonly HttpClient client;
        private readonly string apiKey;

        public OpenWeatherService(IConfiguration configuration)
        {
            client = new();
            apiKey = configuration["OpenWeatherAPIKey"];
        }

        public async Task<IEnumerable<LocationDTO>?> GetLocations(LocationSearchDTO locationSearchDTO)
        {
            IEnumerable<LocationDTO>? locations = null;
            string requestUri = GetGeoRequestUri(locationSearchDTO);

            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
                locations = await response.Content.ReadAsAsync<IEnumerable<LocationDTO>>();

            return locations;
        }

        private string GetGeoRequestUri(LocationSearchDTO locationSearchDTO) =>
            $"https://api.openweathermap.org/geo/1.0/direct?q={locationSearchDTO.Location}&limit=5&appid={apiKey}";
    }