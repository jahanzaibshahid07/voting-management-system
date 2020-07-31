using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace votingmanagementsystem.Models
{
    public class Candidatemodel
    {
        [Required(ErrorMessage = "candidate_id is required.")]
        public int candidate_id { get; set; }
        [Required(ErrorMessage = "name is required.")]
        public string name { get; set; }
        [Required(ErrorMessage = "age is required.")]
        public int age { get; set; }
        [Required(ErrorMessage = "address is required.")]
        public string address { get; set; }
        [Required(ErrorMessage = "email is required.")]
        public string email { get; set; }
        [Required(ErrorMessage = "party_id is required.")]
        public int party_id { get; set; }
    }
}