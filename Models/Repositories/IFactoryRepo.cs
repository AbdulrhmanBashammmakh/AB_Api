namespace AB_Api.Models.Repositories
{
    public interface IFactoryRepo<TEntity>
    {

        IList<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(int id, TEntity entity);
        void Delete(int id);
        List<TEntity> Search(string term);

    }
}
