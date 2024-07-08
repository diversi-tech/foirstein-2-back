using BLL.BllModels;
using BLL.BllService;
<<<<<<< HEAD
using BLL.BllServices;
using BLL.IBll;
using DAL;
=======
using BLL.IBll;
using dal.models;
using DAL;
using DAL.DalService;
using DAL.IDal;
>>>>>>> 75dbee4dcd34de6bb03d90723fe1c7e093864762
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace BLL
{
    public class BlManager
    {
<<<<<<< HEAD
        public IbllBorrowRequest BorrowRequests { get; }
=======
        public IBorrowRequests BorrowRequests { get; }
        public IbllItem Items { get; }
>>>>>>> 75dbee4dcd34de6bb03d90723fe1c7e093864762

        public IbllItemTag bllItemTag { get; }
        public IbllTag bllTag { get; }
        public IbllItem bllItem { get; }
        public IbllRatingNote BlRatingNote { get; }

        public BlManager()
<<<<<<< HEAD
        {
            var services = new ServiceCollection();


            services.AddSingleton<DalManager>();
            services.AddSingleton<IbllBorrowRequest, BllBorrowRequestsService>();
            services.AddSingleton<IbllItem, BllItemService>();
            services.AddSingleton<IbllItemTag, BllItemTagService>();
            services.AddSingleton<IbllTag, BllTagService>();
            services.AddSingleton<IbllRatingNote, BllRatingService>();
=======

        {
            ServiceCollection collections = new ServiceCollection();
            collections.AddSingleton<DalManager>();
            collections.AddSingleton<IBorrowRequests, BorrowRequestsServer>();
            collections.AddSingleton<IbllItem, ItemServer>();


            var serviceprovider = collections.BuildServiceProvider();
            BorrowRequests = serviceprovider.GetRequiredService<IBorrowRequests>();
            Items = serviceprovider.GetRequiredService<IbllItem>();
>>>>>>> 75dbee4dcd34de6bb03d90723fe1c7e093864762

            var serviceProvider = services.BuildServiceProvider();

            BorrowRequests = serviceProvider.GetRequiredService<IbllBorrowRequest>();
            bllItem = serviceProvider.GetRequiredService<IbllItem>();  
            bllItemTag = serviceProvider.GetRequiredService<IbllItemTag>();
            bllTag = serviceProvider.GetRequiredService<IbllTag>();
            BlRatingNote = serviceProvider.GetRequiredService<IbllRatingNote>();

        }
    }
}