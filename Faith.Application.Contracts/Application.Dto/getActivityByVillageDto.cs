using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.Dto
{
    public class getActivityByVillageDto
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        /// <summary>
        /// 所属村(社区)id
        /// </summary>
        public string villageId { get; set; } 
    }
}
