using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Community_Trust.DTOs
{
    // Data Transfer Object
    public class SubmissionDTO
    {
        [Key]
        public int subKey { get; set; }
        [Required]
        [StringLength(255)]
        public string submittedBy { get; set; }

        [Required]
        public string nameOfCause { get; set; }

        public string currentStatus { get; set; }

        [Required]
        public string organisationType { get; set; }

        [Required]
        public string descriptionOfCause { get; set; }


        public string grantCategory { get; set; }


        public string pitch { get; set; }

        // create image class public Image organisationLogo { get; set; }

        public string vidLink { get; set; }


        public string facebookUrl { get; set; }


        public string twittUrl { get; set; }


        public string submitterLocation { get; set; }


        public string useOfFunds { get; set; }

        public string yearAndQuarter { get; set; }

        public bool winner { get; set; }

        public bool paid { get; set; }


        public int externalVotes { get; set; }


        public int internalVotes { get; set; }

        //[Required]

        public string region { get; set; }


        public string notes { get; set; }


        public string causeWebsite { get; set; }

        [Required]
        public bool termsAndConds { get; set; }

        //to see if user has voted on a submission
        private List<String> aspNetUsersIdsVoted { get; set; }
        public string StringListOfSubsVotedFor { get; set; }
        
        public bool hasVotedFor { get; set; }
    }
}