using System.Threading.Tasks;

namespace Mobile.Core.Services.Location
{
    public interface ILocationService
    {
        Task UpdateUserLocation(Mobile.Core.Models.Location.Location location, string token);
    }
}
