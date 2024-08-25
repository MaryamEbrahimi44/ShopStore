using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CatalogPLPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public byte Rate { get; set; }
        public int AvailableStock { get; set; }
    }
}
