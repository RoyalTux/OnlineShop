using AutoMapper;
using OnlineShop.BLL.Dto;
using OnlineShop.Models.Entities;

namespace OnlineShop.Infrastructure
{
	public class WebApiMappingConfig : Profile
	{
		public WebApiMappingConfig()
		{
			this.CreateMap<CategoryView, CategoryDto>().ReverseMap().MaxDepth(2);
			this.CreateMap<ItemView, ItemDto>().ReverseMap().MaxDepth(2);
			this.CreateMap<ItemFeaturesView, ItemFeaturesDto>().ReverseMap().MaxDepth(2);
			this.CreateMap<OrderView, OrderDto>().ReverseMap().MaxDepth(2);
			this.CreateMap<StateView, StateDto>().ReverseMap();
		}
	}
}