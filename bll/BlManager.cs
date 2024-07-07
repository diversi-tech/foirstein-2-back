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

        public BlManager()
        {
            var services = new ServiceCollection();

            services.AddSingleton<DalManager>();

            services.AddSingleton<IbllItemTag, BllItemTagService>();
            services.AddSingleton<IbllTag, BllTagService>();

            var serviceProvider = services.BuildServiceProvider();

            bllItemTag = serviceProvider.GetRequiredService<IbllItemTag>();
            bllTag = serviceProvider.GetRequiredService<IbllTag>();
        
        }
    }
}