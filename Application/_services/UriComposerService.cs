using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public class UriComposerService : IUriComposerService
    {
        public string ComposeImageUri(string src)
        {
            return "https://localhost:44327/" + src.Replace("\\", "//");
        }
    }
}
