using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Varieties.Commands.CreateVariety
{
    public class CreateVarietyCommand : IRequest<CreateVarietyCommandResponse>
    {
        public string Name { get; set; } = string.Empty;

        public Guid ProductId { get; set; }
    }
}
