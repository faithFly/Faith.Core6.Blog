using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.Dto.CatgorizeSugarDto
{
    public class GetCatgorizeDto
    {
        public string catgorizeName { get; set; }
        public int pageSize{ get; set; }
        public int pageIndex { get; set; }
    }
}
