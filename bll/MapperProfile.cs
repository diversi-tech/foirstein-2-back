﻿
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
            CreateMap<BorrowRequest, BllBorrowRequest>().ReverseMap();
            CreateMap<Item, BLLItem>().ReverseMap();
        }


    }
}
