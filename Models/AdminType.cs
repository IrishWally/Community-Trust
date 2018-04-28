using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Community_Trust.Models
{
    public class AdminType
    {
        [Key]
        public byte Id { get; set; }
        public string TypeName { get; set; }
    }
}