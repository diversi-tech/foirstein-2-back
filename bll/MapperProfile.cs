
using AutoMapper;
using BLL.BllModels;
using dal.models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;


namespace BLL
{




    public class MapperProfile : Profile
    {


        public MapperProfile()
        {

            CreateMap<BorrowRequest,BllBorrowRequest>().ReverseMap();
            CreateMap<Item, BllItem>();
            /*   CreateMap<DAL.Models.CommentsToRecipe, CommentsToRecipe>()
                   .ForMember(dest => dest.UserName,
                   opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName)).ReverseMap();
               //CreateMap<CommentsToRecipe, DAL.Models.CommentsToRecipe>();
               CreateMap<DAL.Models.Ingredient, Ingredient>().ReverseMap();
               CreateMap<DAL.Models.IngredientsToRecipe, IngredientsToRecipe>()
                   .ForMember(dest => dest.IngredientName,
                   opt => opt.MapFrom(src => src.Ingredient.Name)).ReverseMap();
               //CreateMap<IngredientsToRecipe, DAL.Models.IngredientsToRecipe>();
               CreateMap<DAL.Models.Level, Level>().ReverseMap();
               CreateMap<DAL.Models.Recipe, Recipe>()
                   .ForMember(dest => dest.UserName,
                   opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                   .ForMember(dest => dest.CategoryName,
                   opt => opt.MapFrom(src => src.Category.Name))
                   .ForMember(dest => dest.LevelName,
                   opt => opt.MapFrom(src => src.Level.Name)).ReverseMap();
               //CreateMap<Recipe, DAL.Models.Recipe>();
               CreateMap<DAL.Models.User, User>().ReverseMap();*/
        }


    }
}
