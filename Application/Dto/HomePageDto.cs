using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class HomePageDto
    {
        public List<BDto> Banners { get; set; }
        public List<CatalogPLPDto> MostPopular { get; set; }
        public List<CatalogPLPDto> bestSellers { get; set; }
    }
}
