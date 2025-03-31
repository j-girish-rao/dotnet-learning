using myDailyTask.BusinessLayer;
using myDailyTask.BusinessLayer.Interfaces;
using myDailyTask.DataAccessLayer;
using myDailyTask.DataAccessLayer.Interfaces;

namespace myDailyTask.Api.Configure
{
    public static class RegisterServices
    {
        public static void RegisterService(this IServiceCollection services) 
        {
            services.AddTransient<ISeverityBusinessLayer, SeverityBusinessLayer>();
            services.AddTransient<ISeverityDataAccess, SeverityDataAccess>();

            services.AddTransient<IUserNotesBusinessLayer, UserNotesBusinessLayer>();
            services.AddTransient<IUserNotesDataAccess, UserNotesDataAccess>();
        }
    }
}
