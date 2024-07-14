using SoapApi.Dtos.Soap;

namespace SoapApi.Dtos.Category
{
    public class ResponseCategoryWithSoapDto :ResponseCategoryDto
    {
        public List<ResponseSoapDto> Soaps { get; set; }
    }
}
