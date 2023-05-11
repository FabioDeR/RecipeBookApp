using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
    {
        public readonly IAsyncRepository<Article> _articleRepository;
        public readonly IMapper _mapper;

        public UpdateArticleCommandHandler(IAsyncRepository<Article> articleRepository,IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<MediatR.Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var articleToUpdate = await _articleRepository.GetByIdAsync(request.ArticleId);

            if (articleToUpdate == null)
            {
                throw new NotFoundException(nameof(Article),request.ArticleId);
            }

            _mapper.Map(request, articleToUpdate);
            await _articleRepository.UpdateAsync(articleToUpdate);
            return MediatR.Unit.Value;
        }
    }
}
