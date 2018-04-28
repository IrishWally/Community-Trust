using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community_Trust.Models
{
    public class EmployeeContribution
    {
        public string FullName { get; set; }
        public string Office { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}