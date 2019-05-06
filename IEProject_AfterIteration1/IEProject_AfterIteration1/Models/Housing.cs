namespace IEProject_AfterIteration1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Housing")]
    public partial class Housing
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Suburb { get; set; }

        public int Rent { get; set; }

        public double Distance { get; set; }

        public int SchoolNo { get; set; }

        public int CrimeNo { get; set; }

        public int Buy_Price { get; set; }

        public int HospitalNo { get; set; }

        public int SupermarketNo { get; set; }

        public int StationNo { get; set; }

        public int NormRent { get; set; }

        public int NormDistance { get; set; }

        public int NormSchools { get; set; }

        public int NormCrime { get; set; }

        public int NormHospital { get; set; }

        public int NormSupermarket { get; set; }

        public int NormStation { get; set; }
    }

    public partial class Housing_Results
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Suburb { get; set; }

        public int CrimeNo { get; set; }

        public int Rent { get; set; }

        public double Distance { get; set; }

        public int SchoolNo { get; set; }

        public int HospitalNo { get; set; }

        public int SupermarketNo { get; set; }

        public int StationNo { get; set; }
    }

    public partial class Updated_Results
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Suburb { get; set; }

        public int SchoolNo { get; set; }

    }

    public partial class Suburb_Map
    {
        [Required]
        [StringLength(250)]
        public string Suburb { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.000000}")]
        public decimal Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.000000}")]
        public decimal Longitude { get; set; }
    }
}
