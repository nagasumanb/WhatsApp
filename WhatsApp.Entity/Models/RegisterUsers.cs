using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WhatsApp.Entity.Models
{
    public class RegisterUsers : IdentityUser
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

    }
}
