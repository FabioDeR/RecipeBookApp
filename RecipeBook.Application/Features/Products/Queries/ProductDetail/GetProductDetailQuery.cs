using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Products.Queries.ProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailVM>
    {
        public Guid Id { get; set; }
    }
}
