namespace AB_Api.Models.Repositories.Local
{
    public class UnitRepo : IFactoryRepo<Unit>
    {

        List<Unit> units;

        public UnitRepo(List<Unit> units)
        {
            this.units = units;
        }

        public void Add(Unit entity)
        {
           units.Add(entity);
        }

        public void Delete(int id)
        {
           var unit = Find(id);
            units.Remove(unit); 
        }

        public Unit Find(int id)
        {
            var unit = units.SingleOrDefault(a => a.Id == id);

            return unit;
        }

        public IList<Unit> List()
        {
            return units;
        }

        public List<Unit> Search(string term)
        {
            return units.Where(i => i.Unit1.Contains(term)).ToList();
                
                }

        public void Update(int id, Unit entity)
        {
            var unit = Find(id);
            unit.Unit1 = entity.Unit1;


        }
    }
}
