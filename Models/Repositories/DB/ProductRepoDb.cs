using AB_Api.Models.FactoryModels;

namespace AB_Api.Models.Repositories.DB
{
    public class ProductRepoDb : IFactoryRepo<ProductFactory>
    {

        private readonly Ab238_salesContext _context;

        public ProductRepoDb(Ab238_salesContext context)
        {
            _context = context;
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
