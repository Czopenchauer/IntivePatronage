using System;

namespace Application.Models
{
    public class BaseUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public bool Gender { get; set; }

        public decimal? Weight { get; set; }
    }
}
