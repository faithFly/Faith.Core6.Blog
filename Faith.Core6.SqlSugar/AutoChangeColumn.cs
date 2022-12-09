using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.SqlSugar
{
    public static class AutoChangeColumn
    {
        /// <summary>
        /// 字符串开头小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string Lowercase(this string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str.Length <= 1)
            {
                throw new ArgumentException(nameof(str));
            }
            return char.ToLower(str[0]) + str.Substring(1);
        }


        /// <summary>
        /// 字符串大写字符前添加 _ 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string LowercaseAdd_(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in str)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    sb.Append('_');
                    sb.Append((char)(c + 32));
                    continue;
                }
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
