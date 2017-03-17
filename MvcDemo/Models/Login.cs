using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class Login
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}