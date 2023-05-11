namespace RecipeBook.Application.Features.Cuts.Commands.CreateCut
{
    public class CutDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}