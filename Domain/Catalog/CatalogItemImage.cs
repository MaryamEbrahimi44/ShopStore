using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Catalog
{
    [Auditable]
    public class CatalogItemImage
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public CatalogItem CatalogItem { get; set;} 
        public int CatalogItemId { get; set;} 
    }
}
