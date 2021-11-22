using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntivePatronage.Models
{
    public class UpdateUserModel
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Gender { get; set; }

        public decimal? Weight { get; set; }
    }
}
