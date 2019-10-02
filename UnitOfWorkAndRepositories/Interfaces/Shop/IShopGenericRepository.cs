using System.Collections.Generic;

namespace UnitOfWorkAndRepositories.Interfaces.Shop
{
	public interface IShopGenericRepository<TInputEntity, TDomainEntity>
		where TInputEntity : class
		where TDomainEntity : class
	{
		IEnumerable<TInputEntity> GetAll();

		//IEnumerable<TInputEntity> FindBy(Expression<Func<TInputEntity, bool>> predicate);

		void Add(TInputEntity entity);

		void Delete(TInputEntity entity);

		void DeleteById(int id);

		void Edit(TInputEntity entity);
	}
}
