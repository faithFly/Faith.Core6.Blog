using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.Dto.Article;
using Faith.EntityModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.IService.Articles
{
    public interface IArticlesService
    {
        Task<ResultDto<T_Article>> InsertArticlesAsync(InsertArticlesDto dto);
    }
}
