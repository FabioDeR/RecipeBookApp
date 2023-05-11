using RecipeBook.Application.Responses;

namespace RecipeBook.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryDto Category { get; set; } = default!;
    }
}