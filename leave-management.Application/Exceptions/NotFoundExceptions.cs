using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leave_management.Application.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string name, object key) : base($"{name} ({key}) was not found")
        {
            
        }
    }
}
