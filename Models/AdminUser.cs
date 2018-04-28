using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Community_Trust.Models
{
    public class AdminUser
    {
        [Key]
        public byte Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool HasAdminRights { get; set; }
        //this is called a navigation type, helps when we need to load two models from the database at the smae time
        public AdminType AdminType { get; set; }
        public byte AdminTypeId { get; set; }
        
        
    }
}