using MediatR;
using RecipeBook.Application.Features.Articles.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Articles.Queries.GetListArticle
{
    public class GetListArticleQuery : IRequest<List<ArticleWithAllIncludeVM>>
    {
    }
}
