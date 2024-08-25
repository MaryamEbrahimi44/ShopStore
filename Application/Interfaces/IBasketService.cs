using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBasketService
    {
        BasketDto GetOrCreateBasketForUser(string BuyerId);
        void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1);
        bool RemoveItemFromBasket(int ItemId);
        bool SetQuantities(int itemId, int quantity);
        BasketDto GetBasketForUser(string UserId);

        void TransferBasket(string anonymousId, string UserId);
    }
}
