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
			this.CreateMap<ItemFeatures, ItemFeatureUnitOfWork>().ReverseMap().MaxDepth(2);
			this.CreateMap<Category, CategoryUnitOfWork>().ReverseMap().MaxDepth(2);
			this.CreateMap<Item, ItemUnitOfWork>().ReverseMap().MaxDepth(2);
			this.CreateMap<Order, OrderUnitOfWork>().ReverseMap().MaxDepth(2);
			this.CreateMap<State, StateUnitOfWork>().ReverseMap();

			this.CreateMap<ShopUser, UserUnitOfWork>().ReverseMap().MaxDepth(2);
			this.CreateMap<ShopRole, RoleUnitOfWork>().ReverseMap().MaxDepth(2);
			this.CreateMap<UserProfile, UserProfileUnitOfWork>().ReverseMap().MaxDepth(2);
		}
	}
}