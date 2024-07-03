using dal.models;
using DAL.DalService;
using DAL.IDal;
using Microsoft.Extensions.DependencyInjection;
namespace DAL;

public class DalManager
{
    public IBorrowApprovalRequest BorrowApprovalRequests { get; }
    public IBorrowRequest BorrowRequests { get; }
    public IItem Items { get; }
    public IItem ItemTags { get; }
    public ISearchLog SearchLogs { get; }
    public ITag Tags { get; }
  

    public DalManager()
    {
        ServiceCollection collections = new ServiceCollection();
        collections.AddSingleton<LiberiansDbContext>();
        collections.AddSingleton<IBorrowApprovalRequest, BorrowApprovalRequestService>();
        collections.AddSingleton<IBorrowRequest, BorrowRequestService>();
        collections.AddSingleton<IItem, ItemService>();
        collections.AddSingleton<IItemTag, ItemTagService>();
        collections.AddSingleton<ISearchLog, SearchLogService>();
        collections.AddSingleton<ITag, TagService>();
        var serviceprovider = collections.BuildServiceProvider();
        BorrowApprovalRequests = serviceprovider.GetRequiredService<IBorrowApprovalRequest>();
        BorrowRequests = serviceprovider.GetRequiredService<IBorrowRequest>();
        Items = serviceprovider.GetRequiredService<IItem>();
        ItemTags = serviceprovider.GetRequiredService<IItem>();
        SearchLogs = serviceprovider.GetRequiredService<ISearchLog>();
        Tags = serviceprovider.GetRequiredService<ITag>();
      
    }

}