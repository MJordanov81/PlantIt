namespace PlantIt.Services.Models.Vendors
{
    using System.Collections.Generic;

    public class VendorsSearchModel
    {
        public string Search { get; set; }

        public IReadOnlyCollection<VendorListModel> Vendors = new List<VendorListModel>();
    }
}
