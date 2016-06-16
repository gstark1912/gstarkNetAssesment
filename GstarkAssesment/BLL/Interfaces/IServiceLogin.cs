using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IServiceLogin
    {
        DTOLoginResult IsCardNumberInvalidOrBlocked(long cardNumber);
        DTOLoginResult Login(long cardNumber, int password);
    }
}
