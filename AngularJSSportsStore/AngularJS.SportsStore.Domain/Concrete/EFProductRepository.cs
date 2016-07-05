using AngularJS.SportsStore.Domain.Abstract;
using AngularJS.SportsStore.Domain.Entities;
using System.Collections.Generic;

namespace AngularJS.SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly IDbFactory dbFactory;
        private EFDbContext dbContext;

        public EFProductRepository(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public EFDbContext DbContext {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public IEnumerable<Product> Products
        {
            get { return DbContext.ProductSet; }
        }

        public void Save(Product product)
        {
            if (product.ProductID == 0)
            {
                DbContext.ProductSet.Add(product);
            }
            else
            {
                Product dbEntry = DbContext.ProductSet.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    //dbEntry.ImageData = product.ImageData;
                    //dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
        }

        public Product Delete(int productID)
        {
            Product dbEntry = DbContext.ProductSet.Find(productID);
            if (dbEntry != null)
            {
                DbContext.ProductSet.Remove(dbEntry);
            }

            return dbEntry;
        }
    }
}
