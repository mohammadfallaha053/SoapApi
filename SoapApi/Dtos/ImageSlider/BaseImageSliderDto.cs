using System.ComponentModel.DataAnnotations;

namespace SoapApi.Dtos.ImageSlider
{
    public class BaseImageSliderDto
    {
        
        public int Order { get; set; }
        public string Image1 { get; set; }

        public byte[]? Image2 { get; set; } = null;

    }
}
