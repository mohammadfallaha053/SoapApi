namespace SoapApi.Models
{
    public class Soap
    {
        public int SoapId { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            public int CategoryId { get; set; }

            public string SoapAge { get; set; }

            public string OliveOil { get; set; }

            public string Color { get; set; }

            public  int  Order { get; set; }=int.MaxValue;

            public  bool  MostWanted { get; set; }=false;
            public string LaurelOil { get; set; }

            public string? Image1 { get; set; }

            public byte[]? Image2 { get; set; }

           public Category Category { get; set; }

    }
}
