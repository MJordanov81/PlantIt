namespace PlantIt.Services.Models.Vendors
{
    using PlantIt.Common.Mapping;
    using PlantIt.Domain;
    using System.ComponentModel.DataAnnotations;

    public class VendorEditModel : IMapFrom<Vendor>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Vendor name must be between 3 and 100 symbols long.")]
        public string Name { get; set; }

        public string WebsiteUrl { get; set; }
    }
}
