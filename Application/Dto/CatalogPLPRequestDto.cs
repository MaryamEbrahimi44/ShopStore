using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CatalogPLPRequestDto
    {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public int? CatalogTypeId { get; set; }
        public int[] BrandId{ get; set; }
        public bool AvailableStock { get; set; }
        //اگه کاربرکلمه سرچ کرد
        public string SearchKey { get; set; }
        public SortType SortType { get; set; }
    }
    public enum SortType
    {
        None=0,
        MostVisited=1,
        BestSelling=2,
        MostPopular=3,
        Newest=4,
        Cheapest=5,
        MostExpensive=6
    }
}
