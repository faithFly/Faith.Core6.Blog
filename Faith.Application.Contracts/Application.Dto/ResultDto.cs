using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.Dto
{
    public class ResultDto<T> where T : class
    {
        public T ResultObj { get; set; }
        public IList<T> ResultData { get; set; }
        public int ResultCode { get; set; }
        public string ResultMsg { get; set; }
        public int ResultSum { get; set; }
    }
}
