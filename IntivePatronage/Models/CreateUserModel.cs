using System;
using System.ComponentModel.DataAnnotations;

namespace IntivePatronage.Models
{
    public class CreateUserModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public bool Gender { get; set; }

        public decimal Weight { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressCountry { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressCity { get; set; }

        [Required]
        [StringLength(10)]
        public string AddressPostCode { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressStreet { get; set; }

        [Required]
        [StringLength(10)]
        public string AddressHouseNumber { get; set; }

        public string AddressLocalNumber { get; set; }

    }
}
