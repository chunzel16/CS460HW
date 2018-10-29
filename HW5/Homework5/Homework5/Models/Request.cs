using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class Request
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please input your First Name"), StringLength(50, ErrorMessage = "Input can be no longer than 50 Characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please input your Last Name"), StringLength(50, ErrorMessage = "Input can be no longer than 50 Characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please input your Phone Number"), RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Phone Number must be in format \"XXX-XXX-XXXX\"")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please input the Apartment Name"), StringLength(50, ErrorMessage = "Input can be no longer than 50 Characters")]
        public string ApartmentName { get; set; }

        [Required(ErrorMessage = "Please input the Unit Number")]
        public int UnitNumber { get; set; }

        [Required(ErrorMessage = "Please input an Explanation")]
        public string Explanation { get; set; }

        [Required]
        public bool Permission { get; set; }


        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} {PhoneNumber} {ApartmentName} UnitNumber = {UnitNumber} {Explanation} Permission = {Permission}";
        }
    }
}