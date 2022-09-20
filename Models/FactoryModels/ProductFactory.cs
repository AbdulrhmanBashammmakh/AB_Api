namespace AB_Api.Models.FactoryModels
{
    public class ProductFactory
    {
        private DateTime _created;
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? UnitId { get; set; }
        public int? CateId { get; set; }
        public string? Code { get; set; }
        public DateTime? CrDate
        {
            get { return _created; }
            set => _created = DateTime.Now;
        }


    }
}
