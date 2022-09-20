namespace AB_Api.Models.Repositories.Local
{
    public class CategoryRepo : IFactoryRepo<Category>
    {

        List<Category> categories;

        public CategoryRepo(List<Category> categories)
        {
            this.categories = categories;
        }

        public void Add(Category entity)
        {
            categories.Add(entity);
        }

        public void Delete(int id)
        {
            var category = Find(id);
                categories.Remove(category);

        }

        public Category Find(int id)
        {
            var category = categories.SingleOrDefault(a => a.Id == id);

            return category;
        }

        public IList<Category> List()
        {
            return categories;
        }

        public List<Category> Search(string term)
        {
            return categories.Where(i => i.Cate.Contains(term)).ToList();
        }

        public void Update(int id, Category entity)
        {
            var category = Find(id);
            category.Cate = entity.Cate;
        }
    }
}
