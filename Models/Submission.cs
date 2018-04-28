using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Community_Trust.Models
{
    public class Submission
    {

        [Key]
        public int subKey { get; set; }
       [Required]
        [StringLength(255)]
        [Display(Name = "Full Name")]
        public string submittedBy { get; set; }

        [Required]
        [Display(Name = "Title of your chosen cause")]
        public string nameOfCause { get; set; }

        public string currentStatus { get; set; }

        [Required]
        [Display(Name = "Type of charitable cause")]
        public string organisationType { get; set; }

        [Required]
        [Display(Name = "Describe your cause in detail")]
        public string descriptionOfCause { get; set; }

        [Display(Name = "Grant Category")]
        public string grantCategory { get; set; }

        [Display(Name = "Why vote for your cause?")]
        public string pitch { get; set; }

        // create image class public Image organisationLogo { get; set; }
        [Display(Name = "Youtube")]
        public string vidLink { get; set; }

        [Display(Name = "Facebook")]
        public string facebookUrl { get; set; }

        [Display(Name = "Twitter")]
        public string twittUrl { get; set; }

        [Display(Name = "What office are you posting from")]
        public string submitterLocation { get; set; }

        [Display(Name = "What will the grant money be used for")]
        public string useOfFunds { get; set; }

        public string yearAndQuarter { get; set; }

        public bool winner { get; set; }

        public bool paid { get; set; }

        [Display(Name = "Public votes")]
        public int externalVotes { get; set; }

        [Display(Name = "Version1 votes")]
        public int internalVotes { get; set; }

        //[Required]
        [Display(Name = "Region")]
        public string region { get; set; }

        [Display(Name = "Other notes")]
        public string notes { get; set; }

        [Display(Name = "Website")]
        public string causeWebsite { get; set; }

        [Required]
        [Display(Name = "Terms and Conditions")]
        public bool termsAndConds { get; set; }

        //to see if user has voted on a submission
       static public List<string> aspNetUsersIdsVoted { get; set; }

        public string StringListOfSubsVotedFor { get; set; }

        public bool hasVotedFor { get; set; }

        //default constructor
        public Submission()
        {

            
        }
    }
}