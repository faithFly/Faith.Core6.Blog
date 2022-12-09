using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.EntityModel.ViewModel
{
    public class UserCheckDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string cause { get; set; }
        /// <summary>
        /// 返回状态码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 是否正确
        /// </summary>
        public string isOk { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; }
    }
}
