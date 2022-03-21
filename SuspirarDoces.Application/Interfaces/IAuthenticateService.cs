using SuspirarDoces.Application.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.Interfaces
{
    public interface IAuthenticateService
    {
        string Authenticate(UserViewModel user, string secretKey);
    }
}
