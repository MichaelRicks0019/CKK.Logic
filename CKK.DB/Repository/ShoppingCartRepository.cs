﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.DB.Interfaces;
using CKK.Logic.Models;

namespace CKK.DB.Repository
{
    class ShoppingCartRepository : IShoppingCartRepository
    {
        public IConnectionFactory conn;
        public ShoppingCartRepository(IConnectionFactory Conn)
        {
            conn = Conn;
        }
        public int Add(ShoppingCartItem entity)
        {
            throw new NotImplementedException();
        }

        public ShoppingCartItem AddToCart(string itemName, int quantity)
        {
            throw new NotImplementedException();
        }

        public int ClearCart(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotal(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public void Ordered(int shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public int Update(ShoppingCartItem entity)
        {
            throw new NotImplementedException();
        }
    }
}