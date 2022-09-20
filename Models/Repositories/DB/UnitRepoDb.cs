

namespace AB_Api.Models.Repositories.DB
{
    public class UnitRepoDb : IFactoryRepo<Unit>
    {

      //  List<Unit> units;
        private readonly Ab238_salesContext _context;
        public UnitRepoDb(Ab238_salesContext context)
        {
            _context = context; 
        }
/*
        public UnitRepoDb(List<Unit> units)
        {
            this.units = units;
        }
*/
        public void Add(Unit entity)
        {
            _context.Units.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var un = Find(id);
            _context.Units.Remove(un);
            _context.SaveChanges();


        }

        public Unit Find(int id)
        {
            var unit = _context.Units.SingleOrDefault(a => a.Id == id);

            return unit;
        }

        public IList<Unit> List()
        {

             
            return _context.Units.ToList();
        }

        public List<Unit> Search(string term)
        {
            var result = _context.Units.Where(b => b.Unit1.Contains(term)).ToList();

            return result;
        }

        public void Update(int id, Unit entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
