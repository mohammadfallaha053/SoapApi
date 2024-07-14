using SoapApi.Dtos.Category;
using SoapApi.Models;

namespace SoapApi.Dtos.Soap
{
    public class ResponseSoapWithCategoryDto : ResponseSoapDto
    {
        public ResponseCategoryDto Category { get; set; }
    }
}
