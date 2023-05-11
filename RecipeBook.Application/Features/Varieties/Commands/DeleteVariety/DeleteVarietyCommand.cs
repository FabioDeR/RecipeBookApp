using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Varieties.Commands.DeleteVariety
{
    public class DeleteVarietyCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
