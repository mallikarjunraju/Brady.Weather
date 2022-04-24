using Brady.Weather.API.Entities;
namespace Brady.Weather.API.Services.GeoCoding
{
    using System.Threading.Tasks;

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
