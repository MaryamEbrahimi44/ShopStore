using Domain.Banners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class BDto
    {

        public int Id { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public Position Position { get; set; }
    }
}
