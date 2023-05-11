using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Gammes.Commands.CreateGamme
{
    public class CreateGammeCommand : IRequest<CreateGammeCommandReponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
