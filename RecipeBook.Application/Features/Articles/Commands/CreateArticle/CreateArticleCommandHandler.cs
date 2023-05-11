using AutoMapper;
using MediatR;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArtcileCommand, string>
    {
        public readonly IArticleRepository _articleRepository;        
        public readonly IMapper _mapper;

        public CreateArticleCommandHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;            
        }

        public async Task<string> Handle(CreateArtcileCommand request, CancellationToken cancellationToken)
        {

            
                var @article = _mapper.Map<Article>(request);
                var validator = new CreateArticleCommandValidator();
                var validationResult = await validator.ValidateAsync(request);
                if (validationResult.Errors.Count > 0)
                {
                    throw new Exceptions.ValidationException(validationResult);
                }
                @article = await _articleRepository.AddAsync(article);

                return "Item was Created";
            
            
          
        }
    }
}
