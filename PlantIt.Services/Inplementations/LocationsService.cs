namespace PlantIt.Services.Inplementations
{
    using System.Threading.Tasks;
    using PlantIt.Services.Models.Locations;
    using PlantIt.Data;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using PlantIt.Domain;

    public class LocationsService : ILocationsService
    {
        private readonly PlantItDbContext db;

        public LocationsService(PlantItDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> Add(string name)
        {
            if (await this.db.Locations.AnyAsync(l => l.Name == name))
            {
                return false;
            }

            await this.db.Locations.AddAsync(new Location
            {
                Name = name
            });

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            Location location = await this.db.Locations.Where(v => v.Id == id).SingleOrDefaultAsync();

            if (location == null)
            {
                return false;
            }
            if (await this.db.Plants.AnyAsync(p => p.LocationId == id))
            {
                return false;
            }

            this.db.Locations.Remove(location);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Edit(int id, string name)
        {
            Location location = await this.db.Locations.Where(v => v.Id == id).SingleOrDefaultAsync();

            if (location == null)
            {
                return false;
            }
            if (await this.db.Locations.AnyAsync(l => l.Name == name))
            {
                return false;
            }

            location.Name = name;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<LocationEditModel> GetLocation(int id)
        {
            return await this.db.Locations
                .Where(v => v.Id == id)
                .ProjectTo<LocationEditModel>()
                .SingleOrDefaultAsync();
        }

        public async Task<LocationsSearchModel> GetLocations(string search)
        {
            LocationListModel[] locations = await this.db.Locations
             .ProjectTo<LocationListModel>()
             .OrderBy(i => i.Name)
             .ToArrayAsync();

            if (!string.IsNullOrEmpty(search))
            {
                locations = locations
                    .Where(i => i.Name.ToLower().Contains(search.ToLower()))
                    .ToArray();
            }

            return new LocationsSearchModel
            {
                Locations = locations,
                Search = search
            };
        }
    }
}
