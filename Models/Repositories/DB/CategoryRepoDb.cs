namespace AB_Api.Models.Repositories.DB
{
    public class CategoryRepoDb : IFactoryRepo<Category>
    {
        private readonly Ab238_salesContext _context;

        public CategoryRepoDb(Ab238_salesContext context)
        {
            _context = context;
        }


        public Category Find(int id)
        {
            var cata = _context.Categories.SingleOrDefault(a => a.Id == id);

            return cata;
        }

        public void Add(Category NewCate)
        {
            _context.Categories.Add(NewCate);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cata = Find(id);
            _context.Categories.Remove(cata);
            _context.SaveChanges();
        }

       

        public IList<Category> List()
        {

            return _context.Categories.ToList();
        }

        public List<Category> Search(string term)
        {
            var result = _context.Categories.Where(b => b.Cate.Contains(term)).ToList();

            return result;
        }

        public void Update(int id, Category entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
