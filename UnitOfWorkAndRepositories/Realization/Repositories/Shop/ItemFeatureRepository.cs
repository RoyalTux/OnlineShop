using System.Data.Entity;
using System.Linq;
using AutoMapper;
using OnlineShop.Domain.Entities.Shop;
using OnlineShop.Domain.Interfaces;
using UnitOfWorkAndRepositories.Entites.Shop;
using UnitOfWorkAndRepositories.Interfaces.Shop;

namespace UnitOfWorkAndRepositories.Realization.Repositories.Shop
{
	public class ItemFeatureRepository : ShopGenericRepository<ItemFeatureUnitOfWork, ItemFeatures>, IItemFeatureRepository
	{
		public ItemFeatureRepository(IEfShopContext context, IMapper mapper)
			: base(context, mapper)
		{ }

		public ItemFeatureUnitOfWork GetById(int id)
		{
			var entity = Mapper.Map<ItemFeatureUnitOfWork>(Dbset.Include(x => x.Item).FirstOrDefault(x => x.ItemFeatureId == id));
			return entity;
		}
	}
}
