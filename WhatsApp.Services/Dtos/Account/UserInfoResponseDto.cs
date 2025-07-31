using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsApp.Services.Dtos.Account
{
    public class UserInfoResponseDto
    {
        public string Id { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }    
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }

    }
}
