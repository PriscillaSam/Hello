using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindConsoleApplication.Data;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NorthwindConsoleApplication.Domain
{
    class ProductManager
    {
        private NORTHWNDEntities dbContext;

        public ProductManager()
        {
            dbContext = new NORTHWNDEntities();
        }

        public int AddProduct(Product product)
        {
            dbContext.Products.Add(product);
            return dbContext.SaveChanges();
            
        }

        public bool SetDiscontinue(int productId, bool status)
        {
            var product = dbContext.Products.Find(productId);
            if (product != null)
            {
                var productEntry = dbContext.Entry(product);
                productEntry.State = EntityState.Modified;
                product.Discontinued = status;

                return dbContext.SaveChanges() > 0;
            }
            return false;
             
        }
    }

}
