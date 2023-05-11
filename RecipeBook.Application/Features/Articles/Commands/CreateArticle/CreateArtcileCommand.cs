using MediatR;
using RecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArtcileCommand : IRequest<string>
    {
        public float Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid CultureId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid GammeId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid? CutId { get; set; }
        public Guid? VarietyId { get; set; }
        public DateTime DLU { get; set; }
        public DateTime DLC { get; set; }
    }
}
