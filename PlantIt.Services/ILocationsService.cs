namespace PlantIt.Services
{
    using PlantIt.Services.Models.Locations;
    using System.Threading.Tasks;

    public interface ILocationsService
    {
        Task<LocationsSearchModel> GetLocations(string search);

        Task<bool> Add(string name);

        Task<LocationEditModel> GetLocation(int id);

        Task<bool> Delete(int id);

        Task<bool> Edit(int id, string name);
    }
}
