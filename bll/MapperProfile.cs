
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
<<<<<<< HEAD

            CreateMap<BorrowRequest,BllBorrowRequest>().ReverseMap();
            CreateMap<ItemTag,BllItemTag>().ReverseMap();
            CreateMap<Tag, BllTag>().ReverseMap();
            CreateMap<Item, BllItem>().ReverseMap();
            CreateMap<RatingNote, BllRatingNote>().ReverseMap();


        
=======
            CreateMap<BorrowRequest, BllBorrowRequest>().ReverseMap();
            CreateMap<Item, BLLItem>().ReverseMap();
>>>>>>> 75dbee4dcd34de6bb03d90723fe1c7e093864762
        }


    }
}
