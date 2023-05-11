using Microsoft.EntityFrameworkCore;
using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Persitence.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(RecipeBookDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Article> GetArticleDetailWithAllInclude(Guid articleId)
        {
            
                Article article = await _dbContext.Articles.Where(d => d.DeleteDate == null && d.Id == articleId)
                    .Include(p => p.Product)
                    .Include(v => v.Variety)
                    .Include(c => c.Culture)
                    .AsNoTracking().FirstAsync();

                return article;
            
            
        }

        public async Task<List<Article>> GetArticleListWithAllInclude()
        {
            List<Article> articles = await _dbContext.Articles.Where(x => x.DeleteDate == null)
                                                              .Include(x => x.Supplier)
                                                              .Include(v => v.Variety)
                                                              .Include(cult => cult.Culture)
                                                              .Include(c => c.Cut)
                                                              .Include(cat => cat.Category)
                                                              .Include(g => g.Gamme)
                                                              .Include(p => p.Product)
                                                              .ThenInclude(u => u.Unit)
                                                              .AsNoTracking()
                                                              .ToListAsync();
            return articles;
        }

        public override async Task<Article> AddAsync(Article entity)
        {
            var myTransaction = _dbContext.Database.BeginTransaction();

            try
            {
                Article article = await base.AddAsync(entity);            

               
                await _dbContext.SaveChangesAsync();

                myTransaction.Commit();
                return article;
            }
            catch (Exception)
            {
                myTransaction.Rollback();
                throw;
            }
            
        }
    }
}
