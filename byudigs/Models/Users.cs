using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace byudigs.Models
{
    public partial class Users
    {
        public Users()
        {
            Burial = new HashSet<Burial>();
        }

        public int UserId { get; set; }
        public string UserInitials { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<Burial> Burial { get; set; }
    }
}
