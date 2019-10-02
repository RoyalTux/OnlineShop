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
			CreateMap<CategoryDto, CategoryUnitOfWork>().ReverseMap().MaxDepth(2);
			CreateMap<ItemDto, ItemUnitOfWork>().ReverseMap().MaxDepth(2);
			CreateMap<ItemFeaturesDto, ItemFeatureUnitOfWork>().ReverseMap().MaxDepth(2);
			CreateMap<OrderDto, OrderUnitOfWork>().ReverseMap().MaxDepth(2);
			CreateMap<StateDto, StateUnitOfWork>().ReverseMap();
			CreateMap<UserDto, UserModelUnitOfWork>().ReverseMap();
		}
	}
}
