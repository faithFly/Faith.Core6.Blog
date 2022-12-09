using Faith.Application.Contracts.Application.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Appliction.Service
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public string Md5(string txt)
        {
            byte[] sor = Encoding.UTF8.GetBytes(txt);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                //加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
                strbul.Append(result[i].ToString("x2"));
            }
            return strbul.ToString();
        }
        public string GetSignString(string phoneNum,string date)
        {
            string dingKey = "8^`ThM>RlqS_UNxW";
            return Md5(date + phoneNum + dingKey);
        }
        public string GetUrlString(string phoneNum, string sign, string date)
        {
            var url = $"https://scdreamtheaterdev.jinlanzuan.com/tv/userCheck?timestamp={date}&mobile={phoneNum}&sign={sign}";
             return url;
        }
        public async Task<string> PostAsyncJson(string url,string json,Dictionary<string,string> header = null) {
            var client = _clientFactory.CreateClient();
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            HttpResponseMessage response = await client.PostAsync(url, content);
            string res = await response.Content.ReadAsStringAsync();
            return res;
        }
    }
}
