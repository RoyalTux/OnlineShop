using OnlineShop.Domain.Entities.Shop;
using UnitOfWorkAndRepositories.Entites.Shop;

namespace UnitOfWorkAndRepositories.Interfaces.Shop
{
	public interface IOrderRepository : IShopGenericRepository<OrderUnitOfWork, Order>
	{
		OrderUnitOfWork GetById(int id);
	}
}
