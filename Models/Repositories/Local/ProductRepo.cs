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
            products.Add(entity);
        }

        public void Delete(int id)
        {
            var product1 = Find(id);
            products.Remove(product1);
        }

        public ProductFactory Find(int id)
        {
            var product1 = products.SingleOrDefault(a => a.Id == id);

            return product1;
        }

        public IList<ProductFactory> List()
        {
            return products;
        }

        public List<ProductFactory> Search(string term)
        {
            return products.Where(i => i.Code.Contains(term) || i.Title.Contains(term)).ToList();
        }

        public void Update(int id, ProductFactory entity)
        {
            var product1 = Find(id);
            product1.Title = entity.Title;
            product1.Code = entity.Code;

            product1.CateId = entity.CateId;

            product1.UnitId = entity.UnitId;

           // product1.Title = entity.Title;


        }
    }
}
