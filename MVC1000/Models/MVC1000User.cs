using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1000.Data
{
    public class MVC1000User : IdentityUser
    {
        [PersonalData]
        [Required]
        public string Firstname { get; set; }
        [PersonalData]
        [Required]
        public string Lastname { get; set; }
        [PersonalData]
        [Required]
        public string PostalCode { get; set; }
        [PersonalData]
        [Required]
        public string StreetName { get; set; }
        [PersonalData]
        [Required]
        public int HouseNumber { get; set; }
    }
}
