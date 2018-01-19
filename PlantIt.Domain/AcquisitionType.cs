namespace PlantIt.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AcquisitionType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage = "Acquisition type name must be between 3 and 100 symbols long.")]
        public string Name { get; set; }

        public ICollection<Plant> Plants { get; set; } = new List<Plant>();
    }
}
