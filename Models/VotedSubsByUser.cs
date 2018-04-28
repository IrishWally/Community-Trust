using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Community_Trust.Models
{
    public class VotedSubsByUser
    {

        [Key]
        public string UserAndSubId { get; set; }
        public string AspNetUserId { get; set; }
        [Required]
        public int SubVotedForId { get; set; }

    }
}