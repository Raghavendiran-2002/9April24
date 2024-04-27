﻿using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class PurchaseRepository : AbstractRepository<int, Purchase>
    {
        static Dictionary<int, Purchase> _purchase;

        public PurchaseRepository()
        {
            _purchase = new Dictionary<int, Purchase>();
        }
        public override async Task<Purchase> Delete(int key)
        {
            Purchase purchase = await GetByKey(key);
            if (purchase != null)
            {
                items.Remove(purchase);
                return purchase;
            }
            throw new UserDefinedException.PurchaseException("Item not found");
        }

        public override async Task< Purchase> GetByKey(int key)
        {
            Purchase purchase = items.FirstOrDefault(p => p.Id == key);
            if (purchase == null)
            {
                throw new UserDefinedException.PurchaseException("Item not found");
                //return null;
            }
            return purchase;
        }

        public override async Task<Purchase> Update(Purchase item)
        {
            Purchase purchase =await GetByKey(item.Id);
            if (purchase != null)
            {
                purchase = item;
            }
            return purchase;
        }
        public async Task<Purchase> ResetById(int purchaseId, Purchase item)
        {
            Purchase purchase = await GetByKey(item.Id);

            if (purchase == null)
                throw new UserDefinedException.NoProductWithGiveIdException();
            purchase.Id = purchaseId;
            purchase.CartItemToPurchase = new Dictionary<string, CartItem>();
            purchase.TotalCost = 0;
            purchase.NoOfItem = 0;            
            return purchase;
        }
    }
}
