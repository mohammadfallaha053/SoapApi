﻿namespace SoapApi.Models
{
    public class ImageSlider
    {
        public int ImageSliderId { get; set; }

        
        public int Order { get; set; }
        public string? Image1 { get; set; }

        public byte[]? Image2 { get; set; } = null;



    }
}
