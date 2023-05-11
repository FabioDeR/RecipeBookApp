using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cultures.Commands.DeleteCulture
{
    public class DeleteCultureCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
