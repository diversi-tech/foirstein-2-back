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
        public IbllItem ibllItem { get; }
        public BlManager()
        {
            var services = new ServiceCollection();
            services.AddSingleton<DalManager>();
            services.AddSingleton<IbllItem, BllItemService>();
            var serviceProvider = services.BuildServiceProvider();
            ibllItem = serviceProvider.GetRequiredService<IbllItem>();
        }
    }
}