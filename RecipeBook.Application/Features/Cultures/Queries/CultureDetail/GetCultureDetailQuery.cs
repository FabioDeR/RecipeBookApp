using MediatR;
using RecipeBook.Application.Features.Cultures.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Cultures.Queries.CultureDetail
{
    public class GetCultureDetailQuery : IRequest<CultureVM>
    {
        public Guid Id { get; set; }
    }
}
