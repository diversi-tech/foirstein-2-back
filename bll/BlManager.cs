using BLL.BllModels;
using BLL.BllService;
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
        public IbllItemTag bllItemTag { get; }
        public IbllTag bllTag { get; }
        public IbllItem bllItem { get; }

        public IbllItemTag bllItemTag { get; }
        public IbllTag bllTag { get; }
        public IbllItem bllItem { get; }
        public IbllRatingNote BlRatingNote { get; }

        public BlManager()
        {
            var services = new ServiceCollection();


            services.AddSingleton<DalManager>();
            services.AddSingleton<IbllItem, BllItemService>();
            services.AddSingleton<IbllItemTag, BllItemTagService>();
            services.AddSingleton<IbllTag, BllTagService>();

            services.AddSingleton<IbllItemTag, BllItemTagService>();
            services.AddSingleton<IbllTag, BllTagService>();
            services.AddSingleton<IbllRatingNote, BllRatingNoteService>();

            var serviceProvider = services.BuildServiceProvider();

            bllItem = serviceProvider.GetRequiredService<IbllItem>();
            bllItemTag = serviceProvider.GetRequiredService<IbllItemTag>();
            bllTag = serviceProvider.GetRequiredService<IbllTag>();


            bllItem = serviceProvider.GetRequiredService<IbllItem>();
            bllItemTag = serviceProvider.GetRequiredService<IbllItemTag>();
            bllTag = serviceProvider.GetRequiredService<IbllTag>();
            BlRatingNote = serviceProvider.GetRequiredService<IbllRatingNote>();

        }
    }
}