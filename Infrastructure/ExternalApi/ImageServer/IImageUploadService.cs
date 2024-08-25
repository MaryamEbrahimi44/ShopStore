using Application.Dto;
using Microsoft.AspNetCore.Http;

using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalApi.ImageServer
{
    public interface IImageUploadService
    {
        List<string> Upload(List<IFormFile> files);
    }
   


  
}
