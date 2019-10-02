using OnlineShop.Domain.Entities.Shop;
using UnitOfWorkAndRepositories.Entites.Shop;

namespace UnitOfWorkAndRepositories.Interfaces.Shop
{
	public interface IItemRepository : IShopGenericRepository<ItemUnitOfWork, Item>
	{
		ItemUnitOfWork GetById(int id);
	}
}
