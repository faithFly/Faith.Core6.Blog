using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.Dto.Article
{
    public class InsertArticlesDto
    {
        public string Id { get; set; }
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
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel { get; set; }
    }
}
