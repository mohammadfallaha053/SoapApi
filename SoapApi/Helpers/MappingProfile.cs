using AutoMapper;
using SoapApi.Dtos;
using SoapApi.Dtos.Category;
using SoapApi.Dtos.ImageSlider;
using SoapApi.Dtos.Soap;
using SoapApi.Dtos.Story;
using SoapApi.Dtos.TeamMemmber;
using SoapApi.Models;

namespace ML.Api.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<TeamMember,ResponseTeamMemberDto>();


            CreateMap<Soap, ResponseSoapDto>();

            CreateMap<Soap, ResponseSoapWithCategoryDto>();

            CreateMap<Category, ResponseCategoryDto>();

            CreateMap<Category, ResponseCategoryWithSoapDto>();

            CreateMap<ImageSlider, ResponseImageSliderDto>();


            CreateMap<Story, ResponseStoryDto>();




            CreateMap<BaseCategoryDto,Category>();

            CreateMap<BaseSoapDto,Soap>();

            CreateMap<BaseTeamMemberDto, TeamMember>();

            CreateMap<BaseImageSliderDto, ImageSlider>();
          
            CreateMap<BaseStoryDto, Story>();




        }
    }
}
