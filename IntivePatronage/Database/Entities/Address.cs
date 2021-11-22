using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntivePatronage.Entities
{
    public class Address
    {           
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Country { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string PostCode { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Street { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string HouseNumber { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string LocalNumber { get; set; }

        public User User { get; set; }
    }
}
