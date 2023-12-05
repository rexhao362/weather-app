public interface IOpenWeatherService
    {
        Task<IEnumerable<LocationDTO>?> GetLocations(LocationSearchDTO locationSearchDTO);
    }