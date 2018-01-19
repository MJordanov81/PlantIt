namespace PlantIt.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Soil
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Soil name must be between 3 and 100 symbols long.")]
        public string Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Soil description must be between 3 and 500 symbols long.")]
        public string Description { get; set; }

        public ICollection<Plant> Plants { get; set; } = new List<Plant>();
    }
}
