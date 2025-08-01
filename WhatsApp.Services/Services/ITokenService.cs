using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsApp.Entity.Models;

namespace WhatsApp.Services.Services
{
    public interface ITokenService
    {
        string CreateToken(RegisterUsers user);
    }
}
