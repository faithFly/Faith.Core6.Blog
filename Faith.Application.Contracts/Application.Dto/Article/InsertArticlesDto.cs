using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.Dto.Article
{
    public class InsertArticlesDto
    {
        /// <summary>
        /// 分类id
        /// </summary>
        public string CategorysId { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string ArticleTitle { get; set; }
        /// <summary>
        /// Md5文件路劲
        /// </summary>
        public string Md5ArticleFileUrl { get; set; }
        public IFormFile file { get; set; }
    }
}
