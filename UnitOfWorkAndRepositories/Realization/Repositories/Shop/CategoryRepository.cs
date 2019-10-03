using System.Data.Entity;
using System.Linq;
using AutoMapper;
using OnlineShop.Domain.Entities.Shop;
using OnlineShop.Domain.Interfaces;
using UnitOfWorkAndRepositories.Entites.Shop;
using UnitOfWorkAndRepositories.Interfaces.Shop;

namespace UnitOfWorkAndRepositories.Realization.Repositories.Shop
{
	public class CategoryRepository : ShopGenericRepository<CategoryUnitOfWork, Category>, ICategoryRepository
	{
		public CategoryRepository(IEfShopContext context, IMapper mapper)
			: base(context, mapper)
		{ }

		public CategoryUnitOfWork GetById(int id)
		{
			CategoryUnitOfWork entity = this.Mapper.Map<CategoryUnitOfWork>(this.Dbset.Include(x => x.Items).FirstOrDefault(x => x.CategoryId == id));
			return entity;
		}
	}
}