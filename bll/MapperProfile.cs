
using AutoMapper;
using BLL.BllModels;
using dal.models;


namespace BLL
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<BorrowRequest, BllBorrowRequest>().ReverseMap();
            CreateMap<BorrowApprovalRequest, BllBorrowApprovalRequest>().ReverseMap();
            CreateMap<ItemTag, BllItemTag>().ReverseMap();
            CreateMap<Tag, BllTag>().ReverseMap();
            CreateMap<Item, BllItem>().ReverseMap();
            CreateMap<RatingNote, BllRatingNote>().ReverseMap();
            CreateMap<SearchLog, BllSearchLog>().ReverseMap();



        }


    }
}
