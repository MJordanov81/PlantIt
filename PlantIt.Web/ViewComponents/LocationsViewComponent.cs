namespace PlantIt.Web.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using PlantIt.Services;
    using PlantIt.Services.Models.Locations;
    using System.Threading.Tasks;

    public class LocationsViewComponent : ViewComponent
    {
        private readonly ILocationsService locations;

        public LocationsViewComponent(ILocationsService locations)
        {
            this.locations = locations;
        }

        public async Task<IViewComponentResult> InvokeAsync(string search)
        {
            LocationsSearchModel locationsList = await this.locations.GetLocations(search);

            return this.View(locationsList);
        }
    }
}
