namespace PlantIt.Web.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using PlantIt.Services;
    using PlantIt.Services.Models.Vendors;
    using System.Threading.Tasks;

    public class VendorsViewComponent : ViewComponent
    {
        private readonly IVendorsService vendors;

        public VendorsViewComponent(IVendorsService vendors)
        {
            this.vendors = vendors;
        }

        public async Task<IViewComponentResult> InvokeAsync(string search)
        {
            VendorsSearchModel vendorsList = await this.vendors.GetVendors(search);

            return this.View(vendorsList);
        }
    }
}
