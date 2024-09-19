using System.ComponentModel.DataAnnotations;

namespace BL.ViewModels
{
    public class ApplicantDTO
    {
        public int Id { get; set; }
        [Required, MinLength(5)]
        public string Name { get; set; }
        [Required, MinLength(5)]

        public string FamilyName { get; set; }
        [Required, MinLength(10)]

        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        [EmailAddress]
        public string EmailAdress { get; set; }
        [Range(20, 60)]
        public int Age { get; set; }
        public bool Hired { get; set; } = false;
    }
}
