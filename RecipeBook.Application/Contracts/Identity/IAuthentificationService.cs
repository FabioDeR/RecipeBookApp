using RecipeBook.Application.Models.Authentification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Contracts.Identity
{
    public interface IAuthentificationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);

        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
