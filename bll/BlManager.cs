using BLL.BllModels;
using BLL.BllService;
using BLL.IBll;
using dal.models;
using DAL;
using DAL.DalService;
using DAL.IDal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BlManager
    {
        public IBorrowRequests BorrowRequests { get; }
        public IbllItem Items { get; }


        public BlManager()

        {
            ServiceCollection collections = new ServiceCollection();
            collections.AddSingleton<DalManager>();
            collections.AddSingleton<IBorrowRequests, BorrowRequestsServer>();
            collections.AddSingleton<IbllItem, ItemServer>();


            var serviceprovider = collections.BuildServiceProvider();
            BorrowRequests = serviceprovider.GetRequiredService<IBorrowRequests>();
            Items = serviceprovider.GetRequiredService<IbllItem>();


        }
    }
}
