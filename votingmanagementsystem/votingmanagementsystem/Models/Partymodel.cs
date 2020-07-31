using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace votingmanagementsystem.Models
{
    public class Partymodel
    {
        [Required(ErrorMessage = "party_id is required.")]
        public int party_id { get; set; }
        [Required(ErrorMessage = "party_name is required.")]
        public string party_name { get; set; }
        [Required(ErrorMessage = "party_logo is required.")]
        public string party_logo { get; set; }
    }
}