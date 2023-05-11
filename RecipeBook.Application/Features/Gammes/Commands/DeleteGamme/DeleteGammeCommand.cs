﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Gammes.Commands.DeleteGamme
{
    public class DeleteGammeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
