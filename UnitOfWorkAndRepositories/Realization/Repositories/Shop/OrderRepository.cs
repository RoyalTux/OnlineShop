using System.Linq;
using AutoMapper;
using OnlineShop.Domain.Entities.Shop;
using OnlineShop.Domain.Interfaces;
using UnitOfWorkAndRepositories.Entites.Shop;
using UnitOfWorkAndRepositories.Interfaces.Shop;

namespace UnitOfWorkAndRepositories.Realization.Repositories.Shop
{
	public class OrderRepository : ShopGenericRepository<OrderUnitOfWork, Order>, IOrderRepository
	{
		public OrderRepository(IEfShopContext context, IMapper mapper)
			: base(context, mapper)
		{ }

		public OrderUnitOfWork GetById(int id)
		{
			var entity = Mapper.Map<OrderUnitOfWork>(Dbset.FirstOrDefault(x => x.OrderId == id));

			return entity;
		}
	}
}
