namespace PlantIt.Services.Models.Vendors
{
    using AutoMapper;
    using PlantIt.Common.Mapping;
    using PlantIt.Domain;

    public class VendorListModel : IMapFrom<Vendor>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string WebsiteUrl { get; set; }

        public int Plants { get; set; }

        public void Configure(Profile profile)
        {
            profile.CreateMap<Vendor, VendorListModel>()
                .ForMember(m => m.Plants, cfg => cfg.MapFrom(v => v.Plants.Count));
        }
    }
}
