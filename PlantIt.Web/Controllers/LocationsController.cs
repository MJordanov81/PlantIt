namespace PlantIt.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PlantIt.Services;
    using System.Threading.Tasks;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using PlantIt.Services.Models.Locations;

    [Authorize()]
    public class LocationsController : Controller
    {
        private readonly ILocationsService locations;

        public LocationsController(ILocationsService location)
        {
            this.locations = location;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLocation(string locationName)
        {
            if (string.IsNullOrWhiteSpace(locationName))
            {
                this.TempData.Add("LocationError", "Location name cannot be empty");

                return this.Redirect(Constants.AdminIndexUrl);
            }

            bool isCreated = await this.locations.Add(locationName);

            if (!isCreated)
            {
                this.TempData.Add("LocationError", "Location with this name already exists");

                return this.Redirect(Constants.AdminIndexUrl);
            }

            return this.Redirect(Constants.AdminIndexUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            bool isDeleted = await this.locations.Delete(id);

            if (!isDeleted)
            {
                this.TempData.Add("LocationError", $"Location with id {id} was not deleted");

                return this.Redirect(Constants.AdminIndexUrl);
            }

            return this.Redirect(Constants.AdminIndexUrl);
        }

        public async Task<IActionResult> EditLocation(int id)
        {
            LocationEditModel location = await this.locations.GetLocation(id);

            if (location == null)
            {
                this.TempData.Add("LocationError", "There is no location with given id");

                return this.Redirect(Constants.AdminIndexUrl);
            }

            return this.View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLocation(LocationEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            bool isEdited = await this.locations.Edit(model.Id, model.Name);

            if (!isEdited)
            {
                ModelState.AddModelError("LocationError", "Location was not edited");

                return this.View(model);
            }

            return this.Redirect(Constants.AdminIndexUrl);
        }

        public IActionResult UpdateLocations(string search)
        {
            if (search == null)
            {
                search = string.Empty;
            }

            return ViewComponent("Locations", new { search = search });
        }
    }
}