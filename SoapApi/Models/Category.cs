namespace SoapApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public LinkedList<Soap> Soaps { get; set; }
    }
}
