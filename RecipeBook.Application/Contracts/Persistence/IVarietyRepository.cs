using RecipeBook.Application.Features.Varieties.Queries.CommonVM;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Contracts.Persistence
{
    public interface IVarietyRepository : IAsyncRepository<Variety>
    {
        Task<VarietyDetailVM> GetVarietyDetailWithProductInfo(Guid id);
        Task<List<VarietyDetailVM>> GetVarietyListWithProductInfo();
    }
}
