namespace PlantIt.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Genus
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Genus name must be between 3 and 100 symbols long.")]
        public string Name { get; set; }

        public ICollection<Species> Species { get; set; } = new List<Species>();
    }
}
