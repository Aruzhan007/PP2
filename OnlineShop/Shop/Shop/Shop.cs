using System;
using System.Collections.Generic;
namespace Shop
{
    public class Shop
    {
        public List<Product> products;
        public Shop(List<Product> products)
        {
            this.products = products;
        }
        public void AddProduct(Product a)
        {
            products.Add(a);
        }
        public void Remove(int i)
        {
            products.RemoveAt(i);
        }
    }
}