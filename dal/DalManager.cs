using dal.models;
using DAL.DalService;
using DAL.IDal;
using Microsoft.Extensions.DependencyInjection;
namespace DAL;

public class DalManager
{
    public IBorrowApprovalRequest BorrowApprovalRequests { get; }
    public IBorrowRequest BorrowRequests { get; }
    public IItem items { get; }
    public IItemTag ItemTags { get; }
    public ISearchLog SearchLogs { get; }
    public ITag Tags { get; }
    public IRatingNote ratingNote { get; }


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
        collections.AddSingleton<IRatingNote, RatingNoteService>();

        var serviceprovider = collections.BuildServiceProvider();
        BorrowApprovalRequests = serviceprovider.GetRequiredService<IBorrowApprovalRequest>();
        BorrowRequests = serviceprovider.GetRequiredService<IBorrowRequest>();
        items = serviceprovider.GetRequiredService<IItem>();
        ItemTags = serviceprovider.GetRequiredService<IItemTag>();
        SearchLogs = serviceprovider.GetRequiredService<ISearchLog>();
        Tags = serviceprovider.GetRequiredService<ITag>();
        ratingNote = serviceprovider.GetRequiredService<IRatingNote>();

    }

}