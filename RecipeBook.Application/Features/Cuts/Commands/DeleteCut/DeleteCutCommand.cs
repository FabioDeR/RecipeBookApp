using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cuts.Commands.DeleteCut
{
    public class DeleteCutCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
