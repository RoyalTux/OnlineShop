using AutoMapper;
using OnlineShop.BLL.Dto;
using OnlineShop.Models.Entities;

namespace OnlineShop.Infrastructure
{
	public class WebApiMappingConfig : Profile
	{
		public WebApiMappingConfig()
		{
			CreateMap<CategoryView, CategoryDto>().ReverseMap().MaxDepth(2);
			CreateMap<ItemView, ItemDto>().ReverseMap().MaxDepth(2);
			CreateMap<ItemFeaturesView, ItemFeaturesDto>().ReverseMap().MaxDepth(2);
			CreateMap<OrderView, OrderDto>().ReverseMap().MaxDepth(2);
			CreateMap<StateView, StateDto>().ReverseMap();
		}
	}
}