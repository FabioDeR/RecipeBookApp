using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Articles.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Articles.Queries.GetListArticle
{
    public class GetListArticleQueryHandler : IRequestHandler<GetListArticleQuery, List<ArticleWithAllIncludeVM>>
    {
        public readonly IArticleRepository _articleRepository;

        public readonly IMapper _mapper;

        public GetListArticleQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<List<ArticleWithAllIncludeVM>> Handle(GetListArticleQuery request, CancellationToken cancellationToken)
        {
            var allArticle = await _articleRepository.GetArticleListWithAllInclude();

            List<ArticleWithAllIncludeVM> articleWithAllIncludeVMs = allArticle.Select(x => new ArticleWithAllIncludeVM()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                CultureId = x.CultureId,
                CultureName = x.Culture.Name,
                CutId = x.CutId,
                CutName = x.Cut.Name,
                DLC = x.DLC,
                DLU = x.DLU,
                GammeId = x.GammeId,
                GammeName = x.Gamme.Name,
                ProductId= x.ProductId,
                ProductName = x.Product.Name,
                Quantity= x.Quantity,
                SupplierId= x.SupplierId,
                SupplierName = x.Supplier.Name,
                VaietyName = x.Variety.Name,
                VarietyId = x.VarietyId,

            }).ToList();

            return articleWithAllIncludeVMs;
        }
    }
}
