using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace form.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Value needed")]
        [StringLength(10,ErrorMessage ="Length 10")]
        public string Username { get; set;}
        [Required]
        public string Password { get; set;}
    }
}