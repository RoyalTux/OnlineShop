using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace OnlineShop.Domain.Interfaces
{
	public interface IEfShopContext
	{
		DbSet<TEntity> Set<TEntity>() where TEntity : class;

		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

		int SaveChanges();

		void Dispose();
	}
}
