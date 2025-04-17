using Ivathu.Madu.BusinessLayer.Interfaces;
using Ivathu.Madu.BusinessLayer;
using Ivathu.Madu.DataAccessLayer.Interfaces;
using Ivathu.Madu.DataAccessLayer;

namespace Ivathu.Madu.Api.Configure
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