namespace Data.Model
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Order Order { get; set; }
        //public Category Category { get; set; }
    }
}
