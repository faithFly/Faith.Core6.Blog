using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.Dto.CatgorizeSugarDto
{
    public class UpdataCategorizeDto
    {
        public int Id { get; set; }
        public string CategorizeName { get; set; }
        public string ParentId { get; set; }
        public int Level { get; set; }
    }
}
