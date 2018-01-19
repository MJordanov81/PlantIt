namespace PlantIt.Services.Models.Locations
{
    using AutoMapper;
    using PlantIt.Common.Mapping;
    using PlantIt.Domain;

    public class LocationListModel : IMapFrom<Location>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Plants { get; set; }

        public void Configure(Profile profile)
        {
            profile.CreateMap<Location, LocationListModel>()
                .ForMember(m => m.Plants, cfg => cfg.MapFrom(l => l.Plants.Count));
        }
    }
}
