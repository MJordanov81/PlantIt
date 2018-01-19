namespace PlantIt.Services.Inplementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using PlantIt.Data;
    using PlantIt.Domain;
    using PlantIt.Services.Models.Vendors;
    using System.Linq;
    using System.Threading.Tasks;

    public class VendorsService : IVendorsService
    {
        private readonly PlantItDbContext db;

        public VendorsService(PlantItDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> Add(string name, string websiteUrl)
        {
            if (await this.db.Vendors.AnyAsync(v => v.Name == name))
            {
                return false;
            }

            await this.db.Vendors.AddAsync(new Vendor
            {
                Name = name,
                WebsiteUrl = websiteUrl ?? string.Empty
            });

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            Vendor vendor = await this.db.Vendors.Where(v => v.Id == id).SingleOrDefaultAsync();

            if (vendor == null)
            {
                return false;
            }
            if (await this.db.Plants.AnyAsync(p => p.VendorId == id))
            {
                return false;
            }

            this.db.Vendors.Remove(vendor);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Edit(int id, string name, string websiteUrl = "")
        {
            Vendor vendor = await this.db.Vendors.Where(v => v.Id == id).SingleOrDefaultAsync();

            if (vendor == null)
            {
                return false;
            }
            if (await this.db.Vendors.AnyAsync(v => v.Name == name))
            {
                return false;
            }

            vendor.Name = name;
            vendor.WebsiteUrl = websiteUrl ?? string.Empty;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<VendorEditModel> GetVendor(int id)
        {
            return await this.db.Vendors
                .Where(v => v.Id == id)
                .ProjectTo<VendorEditModel>()
                .SingleOrDefaultAsync();
        }

        public async Task<VendorsSearchModel> GetVendors(string search)
        {
            VendorListModel[] vendors = await this.db.Vendors
                 .ProjectTo<VendorListModel>()
                 .OrderBy(i => i.Name)
                 .ToArrayAsync();

            if (!string.IsNullOrEmpty(search))
            {
                vendors = vendors
                    .Where(i => i.Name.ToLower().Contains(search.ToLower()))
                    .ToArray();
            }

            return new VendorsSearchModel
            {
                Vendors = vendors,
                Search = search
            };
        }
    }
}
