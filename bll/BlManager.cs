using BLL.BllModels;
using BLL.BllService;
using BLL.BllServices;
using BLL.IBll;
using DAL;
using BLL.IBll;
using dal.models;
using DAL;
using DAL.DalService;
using DAL.IDal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace BLL
{
    public class BlManager
    {
        public IbllBorrowRequest BorrowRequests { get; }
        public IbllItemTag bllItemTag { get; }
        public IbllTag bllTag { get; }
        public IbllItem bllItem { get; }
        public IbllRatingNote BlRatingNote { get; }

        public BlManager()
        {
            var services = new ServiceCollection();


            services.AddSingleton<DalManager>();
            services.AddSingleton<IbllBorrowRequest, BllBorrowRequestsService>();
            services.AddSingleton<IbllItem, BllItemService>();
            services.AddSingleton<IbllItemTag, BllItemTagService>();
            services.AddSingleton<IbllTag, BllTagService>();
            services.AddSingleton<IbllRatingNote, BllRatingNoteService>();

      

    
            var serviceProvider = services.BuildServiceProvider();

            BorrowRequests = serviceProvider.GetRequiredService<IbllBorrowRequest>();
            bllItem = serviceProvider.GetRequiredService<IbllItem>();  
            bllItemTag = serviceProvider.GetRequiredService<IbllItemTag>();
            bllTag = serviceProvider.GetRequiredService<IbllTag>();
            BlRatingNote = serviceProvider.GetRequiredService<IbllRatingNote>();

        }
    }
}