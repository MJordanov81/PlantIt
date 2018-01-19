namespace PlantIt.Services
{
    using PlantIt.Services.Models.Vendors;
    using System.Threading.Tasks;

    public interface IVendorsService
    {
        Task<VendorsSearchModel> GetVendors(string search);

        Task<VendorEditModel> GetVendor(int id);

        Task<bool> Add(string name, string websiteUrl);

        Task<bool> Delete(int id);

        Task<bool> Edit(int id, string name, string websiteUrl);
    }
}
