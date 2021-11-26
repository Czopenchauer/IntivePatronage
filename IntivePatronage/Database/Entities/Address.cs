﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntivePatronage.Entities
{
    public class Address
    {     
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string LocalNumber { get; set; }

        public User User { get; set; }
    }
}
