using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cuts.Commands.CreateCut
{
    public class CreateCutCommand : IRequest<CreateCutCommandResponse>
    {
        public string Name { get; set; } = string.Empty;

    }
}
