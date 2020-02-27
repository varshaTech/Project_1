using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_1.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("UserAdmin")]
    public class useradmin_model
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3)]
        //[RegularExpression(@"^[^<>.,?;:'()!~%\-_@#/*""\s]+$")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Must enter character only")]

        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(30, MinimumLength = 12)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email ID")]

        public string Email_ID { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]

        public string Mobile_No { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(30, MinimumLength = 5)]
        [Required]

        public string Address { get; set; }
        [Required]

        public string Role { get; set; }
        //[RegularExpression(@"^.*(?=.*[!@#$%^&*\(\)_\-+=]).*$")]
        [RegularExpression(@"^(?=.*[A-z])(?=.*[0-9])(?=.*?[!@#$%\^&*\(\)\-_+=;:'""\/\[\]{},.<>|`]).{8,32}$",ErrorMessage = "password must be at least 8 characters long, contain at least one number and special character")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public virtual UserAdmin UserAdmin { get; set; }

        public useradmin_model()
        {
            Date = DateTime.Now;
        }
    }
}