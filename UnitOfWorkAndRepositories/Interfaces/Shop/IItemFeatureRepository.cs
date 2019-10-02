using OnlineShop.Domain.Entities.Shop;
using UnitOfWorkAndRepositories.Entites.Shop;

namespace UnitOfWorkAndRepositories.Interfaces.Shop
{
	public interface IItemFeatureRepository : IShopGenericRepository<ItemFeatureUnitOfWork, ItemFeatures>
	{
		ItemFeatureUnitOfWork GetById(int id);
	}
}
