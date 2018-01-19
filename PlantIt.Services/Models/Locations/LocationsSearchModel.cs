namespace PlantIt.Services.Models.Locations
{
    using System.Collections.Generic;

    public class LocationsSearchModel
    {
        public string Search { get; set; }

        public IReadOnlyCollection<LocationListModel> Locations = new List<LocationListModel>();
    }
}
