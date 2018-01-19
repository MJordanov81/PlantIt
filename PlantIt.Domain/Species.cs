namespace PlantIt.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Species
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Species name must be between 3 and 100 symbols long.")]
        public string Name { get; set; }

        public string Distribution { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int FamilyId { get; set; }

        public Family Family { get; set; }

        public int GenusId { get; set; }

        public Genus Genus { get; set; }

        public ICollection<Plant> Plants { get; set; } = new List<Plant>();
    }
}
