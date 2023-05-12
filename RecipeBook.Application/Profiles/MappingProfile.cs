using AutoMapper;
using RecipeBook.Application.Features.Articles.Commands.CreateArticle;
using RecipeBook.Application.Features.Articles.Commands.UpdateArticle;
using RecipeBook.Application.Features.Categories.Commands.CreateCategory;
using RecipeBook.Application.Features.Categories.Commands.UpdateCategory;
using RecipeBook.Application.Features.Categories.Queries.CommonVM;
using RecipeBook.Application.Features.Cultures.Commands.CreateCulture;
using RecipeBook.Application.Features.Cultures.Commands.UpdateCulture;
using RecipeBook.Application.Features.Cultures.Queries.CommonVM;
using RecipeBook.Application.Features.Cuts.Commands.CreateCut;
using RecipeBook.Application.Features.Cuts.Commands.UpdateCut;
using RecipeBook.Application.Features.Cuts.Queries.CommonVM;
using RecipeBook.Application.Features.Gammes.Commands.CreateGamme;
using RecipeBook.Application.Features.Gammes.Commands.UpdateGamme;
using RecipeBook.Application.Features.Gammes.Queries.CommonVM;
using RecipeBook.Application.Features.Ingredients.Command.CreateIngredient;
using RecipeBook.Application.Features.Ingredients.Command.UpdateIngredient;
using RecipeBook.Application.Features.Ingredients.Queries.IngredientDetail;
using RecipeBook.Application.Features.Products.Commands.CreateProduct;
using RecipeBook.Application.Features.Products.Commands.UpdateProduct;
using RecipeBook.Application.Features.Recipes.Commands.CreateRecipe;
using RecipeBook.Application.Features.Recipes.Queries.CommonVM;
using RecipeBook.Application.Features.Suppliers.Commands.CreateSupplier;
using RecipeBook.Application.Features.Suppliers.Commands.UpdateSupplier;
using RecipeBook.Application.Features.Suppliers.Queries.SupplierDetail;
using RecipeBook.Application.Features.Suppliers.Queries.SupplierList;
using RecipeBook.Application.Features.UnitOfMeasurements.Commands.CreateUnitOfMeasurement;
using RecipeBook.Application.Features.UnitOfMeasurements.Commands.UpdateUnitOfMeasurement;
using RecipeBook.Application.Features.UnitOfMeasurements.Queries.CommonVM;
using RecipeBook.Application.Features.Varieties.Commands.CreateVariety;
using RecipeBook.Application.Features.Varieties.Commands.UpdateVariety;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Article
            CreateMap<Article, CreateArtcileCommand>().ReverseMap();
            CreateMap<Article, UpdateArticleCommand>().ReverseMap();

            //Category
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, CategoryVM>();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            //Culture
            CreateMap<Culture, CreateCultureCommand>().ReverseMap();
            CreateMap<Culture, UpdateCultureCommand>().ReverseMap();
            CreateMap<Culture, CultureVM>().ReverseMap();
            CreateMap<Culture, CultureDto>().ReverseMap();

            //Cut
            CreateMap<Cut, CreateCutCommand>().ReverseMap();
            CreateMap<Cut, CutDto>().ReverseMap();
            CreateMap<Cut, UpdateCutCommand>().ReverseMap();
            CreateMap<Cut, CutVM>().ReverseMap();

            //Gamme
            CreateMap<Gamme, CreateGammeCommand>().ReverseMap();
            CreateMap<Gamme, GammeDto>().ReverseMap();
            CreateMap<Gamme, UpdateGammeCommand>().ReverseMap();
            CreateMap<Gamme, GammeVM>().ReverseMap();

            //Variety
            CreateMap<Variety, CreateVarietyCommand>().ReverseMap();
            CreateMap<Variety, UpdateVarietyCommand>().ReverseMap();
            CreateMap<Variety, VarietyDto>().ReverseMap();


            //UnitOfMeasurement
            CreateMap<UnitOfMeasurement, CreateUnitOfMeasurementCommand>().ReverseMap();
            CreateMap<UnitOfMeasurement, UnitOfMeasurementDto>().ReverseMap();
            CreateMap<UnitOfMeasurement, UnitOfMeasurementDetailVM>().ReverseMap();
            CreateMap<UnitOfMeasurement, UpdateUnitOfMeasurementCommand>().ReverseMap();

            //Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();

            //Supplier
            CreateMap<Supplier, CreateProductCommand>();
            CreateMap<Supplier, UpdateSupplierCommand>().ReverseMap();
            CreateMap<Supplier, SupplierDetailVM>();
            CreateMap<Supplier, SupplierListVM>();
            CreateMap<Supplier, SupplierDto>();


            //RecipeBook
            CreateMap<Recipe, RecipeDto>().ReverseMap();
            CreateMap<Recipe, CreateRecipeCommand>();
            CreateMap<Recipe, RecipeVM>()
                    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                    .ForMember(dest => dest.CultureName, opt => opt.MapFrom(src => src.Culture.Name))
                    .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                    .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name))
                    .ReverseMap();

            //Ingredient
            CreateMap<Ingredient, CreateIngredientCommand>().ReverseMap();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<Ingredient, UpdateIngredientCommand>();
            CreateMap<Ingredient, IngredientVM>()
                    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                    .ForMember(dest => dest.RecipeBookName, opt => opt.MapFrom(src => src.Recipe.Name))
                    .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                    .ForMember(dest => dest.UnitIdName, opt => opt.MapFrom(src => src.Unit.Name))                   
                    .ReverseMap();



        }
    }
}
