using RecipeBook.Application.Contracts.Persistence;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Persitence.Repositories
{
    public class CutRepository : BaseRepository<Cut>, ICutRepository
    {
        public CutRepository(RecipeBookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
