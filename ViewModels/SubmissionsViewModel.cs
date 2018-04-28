using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Community_Trust.Models;
namespace Community_Trust.ViewModels
{
    public class SubmissionsViewModel
    {
        public AdminUser User { get; set; }
        public List<Submission> Submissions{ get; set; }

 
    }
}