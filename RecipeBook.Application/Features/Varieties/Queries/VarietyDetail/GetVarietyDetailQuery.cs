﻿using MediatR;
using RecipeBook.Application.Features.Varieties.Queries.CommonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Varieties.Queries.VarietyDetail
{
    public class GetVarietyDetailQuery : IRequest<VarietyDetailVM>
    {
        public Guid Id { get; set; }
        
    }
}
