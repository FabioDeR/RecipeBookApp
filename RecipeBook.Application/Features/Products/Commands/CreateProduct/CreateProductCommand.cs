using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; } = string.Empty;

        public Guid UnitId { get; set; }

    }
}
