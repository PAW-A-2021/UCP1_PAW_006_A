using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_006_A.Models
{
    public partial class SignIn
    {
        public SignIn()
        {
            Customers = new HashSet<Customer>();
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
