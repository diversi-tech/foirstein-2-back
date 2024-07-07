using BLL.BllModels;
using BLL.BllService;
using BLL.BllServices;
using BLL.IBll;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace BLL
{
    public class BlManager
    {
        public IbllItem ibllItem { get; }
        public IbllRatingNote BlRatingNote { get; }

        public BlManager()
        {
            var services = new ServiceCollection();
            services.AddSingleton<DalManager>();
            services.AddSingleton<IbllItem, BllItemService>();
            services.AddSingleton<IbllRatingNote, BllRatingService>();
            var serviceProvider = services.BuildServiceProvider();
            ibllItem = serviceProvider.GetRequiredService<IbllItem>();
            BlRatingNote = serviceProvider.GetRequiredService<IbllRatingNote>();

        }
    }
}