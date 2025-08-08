using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APi.Models;

namespace APi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}