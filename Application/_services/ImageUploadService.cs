using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Application._services
{
    public class ImageUploadService : IImageUploadService
    {
       
            public List<string> Upload(List<IFormFile> files)
            {
            var options = new RestClientOptions("https://localhost:44327/api/Images?apikey=mysecretkey")
            {
                Timeout = null  // No timeout
            };

            var client = new RestClient(options);

           // var client = new RestClient("https://localhost:44327/api/Images?apikey=mysecretkey");
               // client.Timeout = -1;
                var request = new RestRequest("", Method.Post);
                foreach (var item in files)
                {
                    byte[] bytes;
                    using (var ms = new MemoryStream())
                    {
                        item.CopyToAsync(ms);
                        bytes = ms.ToArray();
                    }
                    request.AddFile(item.FileName, bytes, item.FileName, item.ContentType);
                }


            
            RestResponse response = client.Execute(request);
                UploadDto upload = JsonConvert.DeserializeObject<UploadDto>(response.Content);
                return upload.FileNameAddress;

            }
        }
    }

