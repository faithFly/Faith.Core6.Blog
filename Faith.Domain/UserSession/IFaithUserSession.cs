using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Domain.UserSession
{
    public interface IFaithUserSession
    {
        string GetCurrentUserName();
    }
}
