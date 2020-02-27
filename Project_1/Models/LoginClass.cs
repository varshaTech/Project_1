using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Project_1.Models
{
    public class LoginClass
    {
        //[Required(ErrorMessage ="Date is required")]
        //public Nullable<System.DateTime> Date { get; set; }

        [DisplayName("Email ID")]
        [Required(ErrorMessage = "Email ID is required")]
        public string Email_ID { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}