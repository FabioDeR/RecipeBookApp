using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Articles.Commands.DeleteArtcile
{
    public class DeleteArticleCommand : IRequest
    {
        public Guid ArticleId { get; set; }
    }
}
