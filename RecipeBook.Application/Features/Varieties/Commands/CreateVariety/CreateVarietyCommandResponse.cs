using RecipeBook.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Varieties.Commands.CreateVariety
{
    public class CreateVarietyCommandResponse : BaseResponse
    {



        public VarietyDto VarietyDto { get; set; } = default!;
    }
}
