﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCartItem AddToCart(string itemName, int quantity, int shoppingCartId);

        int ClearCart(int shoppingCartId);

        decimal GetTotal(int shoppingCartId);

        List<ShoppingCartItem> GetProducts(int shoppingCartId);

        void Ordered(int shoppingCartId);

        int Update(ShoppingCartItem entity);

        int Add(ShoppingCartItem entity);
    }
}
