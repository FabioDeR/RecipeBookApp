using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Suppliers.Queries.SupplierList
{
    public class GetSupplierListQuery : IRequest<List<SupplierListVM>>
    {
    }
}
