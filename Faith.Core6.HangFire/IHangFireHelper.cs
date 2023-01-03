using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.HangFire
{
    public interface IHangFireHelper
    {
        void ReadHangFireConfig();
        void HangFireStorage();
    }
}
