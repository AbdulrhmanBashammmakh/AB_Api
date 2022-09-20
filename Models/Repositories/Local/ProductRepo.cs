using AB_Api.Models.FactoryModels;

namespace AB_Api.Models.Repositories.Local
{
    public class ProductRepo : IFactoryRepo<ProductFactory>
    {


        IList<ProductFactory> products;
        public ProductRepo(IList<ProductFactory> _products)
        {
            products = _products;
        }

        public void Add(ProductFactory entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProductFactory Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProductFactory> List()
        {
            throw new NotImplementedException();
        }

        public List<ProductFactory> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ProductFactory entity)
        {
            throw new NotImplementedException();
        }
    }
}
