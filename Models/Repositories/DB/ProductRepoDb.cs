using AB_Api.Models.FactoryModels;

namespace AB_Api.Models.Repositories.DB
{
    public class ProductRepoDb : IFactoryRepo<ProductFactory>
    {

        private readonly Ab238_salesContext DB;
          public  IList<Product> productsList;

        public ProductRepoDb(Ab238_salesContext context, IList<Product> productsList)
        {
            DB = context;
            this.productsList = productsList;
        }

        public void Add(ProductFactory entity)
        {
            DB.Products.Add(new Product{ Title = entity.Title
            ,Code=entity.Code
            ,UnitId=entity.UnitId   
            ,CateId=entity.CateId
            ,CrDate=DateTime.Now
            });
            DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var product1 = Find(id);
       
            DB.Products.Remove(product1);
            DB.SaveChanges();
        }

        public Product Find(int id)
        {
            var product1 = DB.Products.Find(id);
            return product1;
        }

        public IList<Product> List()
        {
            var products = DB.Products.ToList();
            productsList.Clear();
            productsList = products;
            return productsList;
        }

        public List<Product> Search(string term)
        {
            if (productsList.Equals(null))
            {
                List();
            }
            return productsList.Where(i => i.Code.Contains(term) || i.Title.Contains(term)).ToList();

        }

        public void Update(int id, ProductFactory entity)
        {
            var product1 = Find(id);
            product1.Title = entity.Title;
            product1. Code = entity.Code;
            product1. UnitId = entity.UnitId;
            product1. CateId = entity.CateId;
            DB.SaveChanges();
        }

        ProductFactory IFactoryRepo<ProductFactory>.Find(int id)
        {
            throw new NotImplementedException();
        }

        IList<ProductFactory> IFactoryRepo<ProductFactory>.List()
        {
            throw new NotImplementedException();
        }

        List<ProductFactory> IFactoryRepo<ProductFactory>.Search(string term)
        {
            throw new NotImplementedException();
        }
    }
}
