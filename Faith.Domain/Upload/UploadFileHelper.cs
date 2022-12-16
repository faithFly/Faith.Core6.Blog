using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faith.Application.Contracts.Application.Dto.ExceptionDto;
using Microsoft.Extensions.Configuration;

namespace Faith.Domain.Upload
{
    public class UploadFileHelper
    {
        private readonly IConfiguration _configuration;
        public UploadFileHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async ValueTask<string> UploadFileAsync(Microsoft.AspNetCore.Http.IFormFile file) {
            var fileUrl = _configuration["TxtFileUrl"];
            if (file == null)
            {
                throw new UserFriendlyException(404, "文件不能为空！");
            }
            if (file.FileName.Split('.')[1] != "txt")
            {
                throw new UserFriendlyException(404, "文件格式有误！");
            }
            var createFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + file.FileName;
            await using var memoryStream = new System.IO.MemoryStream();
            //将文件复制到流中
            await file.CopyToAsync(memoryStream);
            FileStream fs = new FileStream($"{fileUrl}{createFileName}", FileMode.OpenOrCreate);
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(memoryStream.ToArray());
            fs.Close();
            memoryStream.Close();
            return $"{fileUrl}{createFileName}";
        }
    }
}
