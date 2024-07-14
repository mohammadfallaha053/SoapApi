namespace SoapApi.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string? Image1 { get; set; }

        public byte[]? Image2 { get; set; }




    }
}
