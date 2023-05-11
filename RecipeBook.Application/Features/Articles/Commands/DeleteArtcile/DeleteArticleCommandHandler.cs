using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Application.Exceptions;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Articles.Commands.DeleteArtcile
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IAsyncRepository<Article> _articleRepository;

        public DeleteArticleCommandHandler(IAsyncRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<MediatR.Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var articleDeleted = await _articleRepository.GetByIdAsync(request.ArticleId);

            if(articleDeleted == null)
            {
                throw new NotFoundException(nameof(Article), request.ArticleId);
            }

            await _articleRepository.DeleteAsync(articleDeleted);

            return MediatR.Unit.Value;
        }
    }
}
