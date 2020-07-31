using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace votingmanagementsystem.Models
{
    public class Constituencymodel
    {
        [Required(ErrorMessage = "constituent_id is required.")]
        public int constituent_id { get; set; }
        [Required(ErrorMessage = "address is required.")]
        public string address { get; set; }
        [Required(ErrorMessage = "constituent_no is required.")]
        public string constituent_no { get; set; }
        [Required(ErrorMessage = "election_id is required.")]
        public int election_id { get; set; }
    }
}