
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Contracts.Persistence
{
    public interface IArticleRepository : IAsyncRepository<Article>
    {
        Task<Article> GetArticleDetailWithAllInclude(Guid articleId);
        Task<List<Article>> GetArticleListWithAllInclude();
    }
}
