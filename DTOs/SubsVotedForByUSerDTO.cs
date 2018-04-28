using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Community_Trust.DTOs
{
    public class SubsVotedForByUSerDTO
    {
        //Data transfer Object
        //composite key
        [Key]
        public string UserAndSubId { get; set; }
        public string AspNetUserId { get; set; }
       [Required]
        public int SubVotedForId { get; set; }
    }
}