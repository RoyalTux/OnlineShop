using AutoMapper;
using OnlineShop.Domain.Entities.Account;
using OnlineShop.Domain.Entities.Shop;
using UnitOfWorkAndRepositories.Entites.Account;
using UnitOfWorkAndRepositories.Entites.Shop;

namespace UnitOfWorkAndRepositories.Infrastructure
{
	public class UnitOfWorkMappingConfig : Profile
	{
		public UnitOfWorkMappingConfig()
		{
			CreateMap<ItemFeatures, ItemFeatureUnitOfWork>().ReverseMap().MaxDepth(2);
			CreateMap<Category, CategoryUnitOfWork>().ReverseMap().MaxDepth(2);
			CreateMap<Item, ItemUnitOfWork>().ReverseMap().MaxDepth(2);
			CreateMap<Order, OrderUnitOfWork>().ReverseMap().MaxDepth(2);
			CreateMap<State, StateUnitOfWork>().ReverseMap();

			CreateMap<ShopUser, UserUnitOfWork>().ReverseMap().MaxDepth(2);
			CreateMap<ShopRole, RoleUnitOfWork>().ReverseMap().MaxDepth(2);
			CreateMap<UserProfile, UserProfileUnitOfWork>().ReverseMap().MaxDepth(2);
		}
	}
}
