using curso.api.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Configuration
{
    public interface IAuthenticationService
    {
        string GerarToken(UserViewModel userViewModel);
    }
}
