namespace PlantIt.Domain
{
    using System;

    public class Plant
    {
        public int Id { get; set; }

        public string Size { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public int AgeAtAcquisition { get; set; }

        public string PotType { get; set; }

        public string PhotoUrl { get; set; }

        public string Comments { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public int SpeciesId { get; set; }

        public Species Species { get; set; }

        public int AcquisitionTypeId { get; set; }

        public AcquisitionType AcquisitionType { get; set; }

        public int VendorId { get; set; }

        public Vendor Vendor { get; set; }

        public int SoilId { get; set; }

        public Soil Soil { get; set; }
    }
}
