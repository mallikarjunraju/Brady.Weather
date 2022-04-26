namespace Brady.Weather.API.Services.Interfaces
{
    using System.Threading.Tasks;
    using Brady.Weather.API.Entities;

    /// <summary>
    /// IGeoCodingService interface.
    /// </summary>
    public interface IGeoCodingService
    {
        /// <summary>
        /// Gets the latitude and longitude for a given city.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public Task<Coordinates> GetCityCoordinates(string city);
    }
}
