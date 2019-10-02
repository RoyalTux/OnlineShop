using OnlineShop.Domain.Entities.Shop;
using UnitOfWorkAndRepositories.Entites.Shop;

namespace UnitOfWorkAndRepositories.Interfaces.Shop
{
	public interface ICategoryRepository : IShopGenericRepository<CategoryUnitOfWork, Category>
	{
		CategoryUnitOfWork GetById(int id);
	}
}
