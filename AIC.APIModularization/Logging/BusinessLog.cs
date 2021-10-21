using Excellerent.APIModularization.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.APIModularization.Logging
{
    public class BusinessLog : IBusinessLog
    {
        public void LogToDb(string application, BusinessLogModel businessLogModel, UserModel user, string feature, object data, object previousData)
        {
            throw new NotImplementedException();
        }
    }
}
