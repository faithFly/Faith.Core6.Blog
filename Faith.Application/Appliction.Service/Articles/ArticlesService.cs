using Faith.Application.Contracts.Application.Dto;
using Faith.Application.Contracts.Application.Dto.Article;
using Faith.Application.Contracts.Application.Dto.ExceptionDto;
using Faith.Application.Contracts.Application.IService.Articles;
using Faith.DbMigrator.Faith.Dbcontext;
using Faith.Domain.Upload;
using Faith.EntityModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Appliction.Service.Articles
{
    public class ArticlesService : IArticlesService
    {
        private readonly faithdbContext faithdbContext;

        public ArticlesService(faithdbContext faithdbContext)
        {
            this.faithdbContext = faithdbContext;
        }

        public async Task<ResultDto<T_Article>> InsertArticlesAsync(InsertArticlesDto dto)
        {
            T_Article t_Article = new T_Article
            {
                Id = Guid.NewGuid().ToString(),
                ArticleTitle = dto.ArticleTitle,
                Md5ArticleFileUrl = dto.Md5ArticleFileUrl,
                CategorysId = dto.CategorysId,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            await faithdbContext.T_Articles.AddAsync(t_Article);
            var flag = await faithdbContext.SaveChangesAsync() > 0 ? true : false;
            if (flag)
            {
                return new ResultDto<T_Article> { ResultCode = 200, ResultMsg = "添加成功！" };
            }
            else
            {
                throw new UserFriendlyException(400, "插入失败！");
            }
        }

    }
}
