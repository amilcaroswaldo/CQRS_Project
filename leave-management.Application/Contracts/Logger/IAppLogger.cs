using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leave_management.Application.Contracts.Logger
{
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarnig(string message, params object[] args);  
    }
}
