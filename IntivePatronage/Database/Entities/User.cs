using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntivePatronage.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "datetime2(0)")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Gender { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Weight { get; set; }

        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}
