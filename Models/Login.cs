using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EshopApi.Models
{
    public class Login
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
    }
}
