using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Features.Articles.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Articles.Queries.ArticleDetail
{
    internal class GetArticleDetailQueryHandler : IRequestHandler<GetArticleDetailQuery, ArticleWithAllIncludeVM>
    {
        public readonly IArticleRepository _articleRepository;
        public readonly IMapper _mapper;

        public GetArticleDetailQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<ArticleWithAllIncludeVM> Handle(GetArticleDetailQuery request, CancellationToken cancellationToken)
        {
            var articleWithInclude = await _articleRepository.GetArticleDetailWithAllInclude(request.ArticleId);
            ArticleWithAllIncludeVM articleWithAllIncludeVM = new()
            {
                ArticleId = request.ArticleId,
                CategoryId = articleWithInclude.CategoryId,
                CategoryName = articleWithInclude.Category.Name,
                CultureId = articleWithInclude.CultureId,
                CultureName = articleWithInclude.Culture.Name,
                CutId = articleWithInclude.CutId,
                CutName = articleWithInclude.Cut.Name,
                DLC = articleWithInclude.DLC,
                DLU = articleWithInclude.DLU,
                GammeId = articleWithInclude.GammeId,
                GammeName = articleWithInclude.Gamme.Name,
                ProductId = articleWithInclude.ProductId,
                ProductName = articleWithInclude.Product.Name,
                Quantity = articleWithInclude.Quantity,
                SupplierId = articleWithInclude.SupplierId,
                SupplierName = articleWithInclude.Supplier.Name,
                VaietyName = articleWithInclude.Variety.Name,
                VarietyId = articleWithInclude.Variety.Id,
               
            };

            return articleWithAllIncludeVM;

        }
    }
}
