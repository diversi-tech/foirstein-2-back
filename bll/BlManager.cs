using BLL.BllService;
using BLL.BllServices;
using BLL.IBll;
using DAL;
using Microsoft.Extensions.DependencyInjection;


namespace BLL
{
    public class BlManager
    {
        public IbllBorrowRequest BorrowRequests { get; }
        public IbllItemTag bllItemTag { get; }
        public IbllTag bllTag { get; }
        public IbllItem bllItem { get; }
        public IbllRatingNote BlRatingNote { get; }
        public IbllSearchLog bllSearchLog { get; }

        public BlManager()
        {
            var services = new ServiceCollection();


            services.AddSingleton<DalManager>();
            services.AddSingleton<IbllBorrowRequest, BllBorrowRequestsService>();
            services.AddSingleton<IbllItem, BllItemService>();
            services.AddSingleton<IbllItemTag, BllItemTagService>();
            services.AddSingleton<IbllTag, BllTagService>();
            services.AddSingleton<IbllRatingNote, BllRatingNoteService>();
            services.AddSingleton<IbllSearchLog, BllSearchLogService>();


            var serviceProvider = services.BuildServiceProvider();

            BorrowRequests = serviceProvider.GetRequiredService<IbllBorrowRequest>();
            bllItem = serviceProvider.GetRequiredService<IbllItem>();
            bllItemTag = serviceProvider.GetRequiredService<IbllItemTag>();
            bllTag = serviceProvider.GetRequiredService<IbllTag>();
            BlRatingNote = serviceProvider.GetRequiredService<IbllRatingNote>();
            bllSearchLog = serviceProvider.GetRequiredService<IbllSearchLog>();

        }
    }
}