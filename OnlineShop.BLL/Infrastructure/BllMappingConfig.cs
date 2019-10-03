using AutoMapper;
using OnlineShop.BLL.Dto;
using UnitOfWorkAndRepositories.Entites.Account;
using UnitOfWorkAndRepositories.Entites.Shop;

namespace OnlineShop.BLL.Infrastructure
{
	public class BllMappingConfig : Profile
	{
		public BllMappingConfig()
		{
			this.CreateMap<CategoryDto, CategoryUnitOfWork>().ReverseMap().MaxDepth(2);
			this.CreateMap<ItemDto, ItemUnitOfWork>().ReverseMap().MaxDepth(2);
			this.CreateMap<ItemFeaturesDto, ItemFeatureUnitOfWork>().ReverseMap().MaxDepth(2);
			this.CreateMap<OrderDto, OrderUnitOfWork>().ReverseMap().MaxDepth(2);
			this.CreateMap<StateDto, StateUnitOfWork>().ReverseMap();
			this.CreateMap<UserDto, UserModelUnitOfWork>().ReverseMap();
		}
	}
}