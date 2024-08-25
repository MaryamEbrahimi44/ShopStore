using Domain.Attributes;
using Domain.Catalog;

namespace Domain.Orders
{
    [Auditable]
    public class OrderItem
    {
        public int Id { get;private set; }
        public int UnitPrice { get; private set; }
        public int Units { get; private set; }
        public CatalogItem CatalogItem { get; private set; }
        public int CatalogItemId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }
        public OrderItem(int catalogItemId,int unitPrice,int units,string productName, string pictureUri)
        {
            CatalogItemId=catalogItemId;
            UnitPrice=unitPrice;
            Units=units;
            ProductName=productName;
            PictureUri=pictureUri;
                
        }
        public OrderItem()
        {
                
        }

    }
}
