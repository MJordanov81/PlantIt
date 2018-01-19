namespace PlantIt.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PlantIt.Services;
    using PlantIt.Services.Models.Vendors;
    using System.Threading.Tasks;
    using Infrastructure;

    [Authorize()]
    public class VendorsController : Controller
    {
        private readonly IVendorsService vendors;

        public VendorsController(IVendorsService vendors)
        {
            this.vendors = vendors;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVendor(string vendorName, string vendorWebsiteUrl)
        {
            if (string.IsNullOrWhiteSpace(vendorName))
            {
                this.TempData.Add("VendorError", "Vendor name cannot be empty");

                return this.Redirect(Constants.AdminIndexUrl);
            }

            bool isCreated = await this.vendors.Add(vendorName, vendorWebsiteUrl);

            if (!isCreated)
            {
                this.TempData.Add("VendorError", "Vendor with this name already exists");

                return this.Redirect(Constants.AdminIndexUrl);
            }

            return this.Redirect(Constants.AdminIndexUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            bool isDeleted = await this.vendors.Delete(id);

            if (!isDeleted)
            {
                this.TempData.Add("VendorError", $"Vendor with id {id} was not deleted");

                return this.Redirect(Constants.AdminIndexUrl);
            }

            return this.Redirect(Constants.AdminIndexUrl);
        }

        public async Task<IActionResult> EditVendor(int id)
        {
            VendorEditModel vendor = await this.vendors.GetVendor(id);

            if (vendor == null)
            {
                this.TempData.Add("VendorError", "There is no vendor with given id");

                return this.Redirect(Constants.AdminIndexUrl);
            }

            return this.View(vendor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVendor(VendorEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            bool isEdited = await this.vendors.Edit(model.Id, model.Name, model.WebsiteUrl ?? string.Empty);

            if (!isEdited)
            {
                ModelState.AddModelError("VendorError", "Vendor was not edited");

                return this.View(model);
            }

            return this.Redirect(Constants.AdminIndexUrl);
        }

        public IActionResult UpdateVendors(string search)
        {
            if (search == null)
            {
                search = string.Empty;
            }

            return ViewComponent("Vendors", new { search = search });
        }
    }
}