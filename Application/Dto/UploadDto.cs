using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UploadDto
    {
        public bool Status { get; set; }
        public List<string> FileNameAddress { get; set; }
    }
}
