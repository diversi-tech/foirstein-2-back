using DAL.DalApi;
using DAL.DalImplementation;
using DAL.Do;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public class DalManager
{
    //public IJobRequest JobRequests { get; }
    //public IBoss Bosses { get; }
    //public IFiled Fileds { get; }
    //public IJobOffer JobOffers { get; }
    //public ITypeOfSalary TypeOfSalaries { get; }
    //public IInterview Interviews { get; }
    //public ITest Tests { get; }
    //public IQuestion Questions { get; }

    public DalManager()
    {
        ServiceCollection collections = new ServiceCollection();
        /*collections.AddSingleton<dbcontext>();
        collections.AddSingleton<IBoss, BossService>();
        collections.AddSingleton<IFiled, FiledService>();
        collections.AddSingleton<IJobOffer, JobOfferService>();
        collections.AddSingleton<IJobRequest, JobRequestService>();
        collections.AddSingleton<ITypeOfSalary, TypeOfSalaryService>();
        collections.AddSingleton<IInterview, InterviewService>();
        collections.AddSingleton<ITest, TestService>();
        collections.AddSingleton<IQuestion, QuestionService>();
        var serviceprovider = collections.BuildServiceProvider();

        Bosses = serviceprovider.GetRequiredService<IBoss>();
        JobRequests = serviceprovider.GetRequiredService<IJobRequest>();
        Fileds = serviceprovider.GetRequiredService<IFiled>();
        JobOffers = serviceprovider.GetRequiredService<IJobOffer>();
        TypeOfSalaries = serviceprovider.GetRequiredService<ITypeOfSalary>();
        Interviews = serviceprovider.GetRequiredService<IInterview>();
        Tests = serviceprovider.GetRequiredService<ITest>();*/
        /*Questions = serviceprovider.GetRequiredService<IQuestion>();*/
    }

}