namespace PlantIt.Services.Models.Locations
{
    using PlantIt.Common.Mapping;
    using PlantIt.Domain;
    using System.ComponentModel.DataAnnotations;

    public class LocationEditModel : IMapFrom<Location>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Location name must be between 3 and 100 symbols long.")]
        public string Name { get; set; }
    }
}
