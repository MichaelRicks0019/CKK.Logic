using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    public interface IShoppingCartRepository
    {
        /*ShoppingCartItem AddToCart(string itemName, int quantity);*/

        //Regular Methods

        //Removes rows in database that have the given ShoppingCartId
        int ClearCart(int shoppingCartId);
        //Gets total cost of Cart
        decimal GetTotal(int shoppingCartId);
        //Returns List of ShoppingCartItems that are in the same "cart" (have same Id)
        List<ShoppingCartItem> GetProducts(int shoppingCartId);
        //Creates order using the ShoppingCartId
        void Ordered(int shoppingCartId);
        //Replaces "updates" the ShopppingCartItem using the CustomerId as reference.
        int Update(ShoppingCartItem entity);
        //Adds ShoppingCartItem to the database. This can be used to add what a client wants to their cart
        int Add(ShoppingCartItem entity);

        //Async Methods

        //Same as above just asynchronous
        Task<int> UpdateAsync(ShoppingCartItem entity);

        Task<int> AddAsync(ShoppingCartItem entity);
    }
}
