using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cultures.Commands.CreateCulture
{
    public class CreateCultureCommand : IRequest<CreateCultureCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
