using RecipeBook.API;

var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigurationService()
                 .ConfigurationPipeline();

await app.ResetDataBaseAsync();

app.Run();
