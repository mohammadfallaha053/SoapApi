namespace SoapApi.Dtos.Soap
{
    public class BaseSoapDto
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string SoapAge { get; set; }

        public string Color { get; set; }
        public string OliveOil { get; set; }

        public string LaurelOil { get; set; }

        public string? Image1 { get; set; }

        public byte[]? Image2 { get; set; }

        public int Order { get; set; } 

        public bool MostWanted { get; set; } 
    }
}
