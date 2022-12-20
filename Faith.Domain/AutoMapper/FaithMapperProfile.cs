using AutoMapper;
using Faith.Application.Contracts.Application.Dto.CatgorizeSugarDto;
using Faith.Core6.SqlSugar.Repsoitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Domain.AutoMapper
{
    public class FaithMapperProfile : Profile
    {
        public FaithMapperProfile() {
            CreateMap<UpdataCategorizeDto, T_CategorizeSugar>();
        }
    }
}
