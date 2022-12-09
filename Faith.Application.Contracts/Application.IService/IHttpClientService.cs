using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Contracts.Application.IService
{
    public interface IHttpClientService
    {
        string Md5(string txt);
        string GetSignString(string phoneNum, string date);
        string GetUrlString(string phoneNum, string sign, string date);
        Task<string> PostAsyncJson(string url, string json, Dictionary<string, string> header = null);
    }
}
