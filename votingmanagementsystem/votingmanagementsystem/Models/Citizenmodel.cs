using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace votingmanagementsystem.Models
{
    public class Citizenmodel
    {
        [Required(ErrorMessage = "citizen_id is required.")]
        public int citizen_id { get; set; }
        [Required(ErrorMessage = "name is required.")]
        public string name { get; set; }
        [Required(ErrorMessage = "age is required.")]
        public string age { get; set; }
        [Required(ErrorMessage = "address is required.")]
        public string address { get; set; }
        [Required(ErrorMessage = "email is required.")]
        public string email { get; set; }
        [Required(ErrorMessage = "cnic_no is required.")]
        public int cnic_no { get; set; }
        [Required(ErrorMessage = "constituent_id is required.")]
        public int constituent_id { get; set; }
    }
}