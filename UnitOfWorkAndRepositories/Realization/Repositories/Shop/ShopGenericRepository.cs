using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using OnlineShop.Domain.Interfaces;
using UnitOfWorkAndRepositories.Interfaces.Shop;

namespace UnitOfWorkAndRepositories.Realization.Repositories.Shop
{
	public abstract class ShopGenericRepository<TInputEntity, TDomainEntity> : IShopGenericRepository<TInputEntity, TDomainEntity>
		where TInputEntity : class
		where TDomainEntity : class
	{
		private readonly IEfShopContext _entities;
		protected readonly IDbSet<TDomainEntity> Dbset;
		protected readonly IMapper Mapper;

		protected ShopGenericRepository(IEfShopContext context, IMapper mapper)
		{
			_entities = context;
			Dbset = _entities.Set<TDomainEntity>();
			this.Mapper = mapper;
		}

		public virtual IEnumerable<TInputEntity> GetAll()
		{
			return Mapper.Map<IEnumerable<TInputEntity>>(Dbset.AsEnumerable<TDomainEntity>());
		}

		public virtual void Add(TInputEntity inputEntity)
		{
			var entity = Mapper.Map<TDomainEntity>(inputEntity);
			Dbset.Add(entity);
		}

		public virtual void Delete(TInputEntity inputEntity)
		{
			var entity = Mapper.Map<TDomainEntity>(inputEntity);
			Dbset.Remove(entity);
		}

		public virtual void DeleteById(int id)
		{
			var findEntity = Dbset.Find(id);
			Dbset.Remove(findEntity);
			var entity = Mapper.Map<TInputEntity>(findEntity);
		}

		public virtual void Edit(TInputEntity inputEntity)
		{
			var entity = Mapper.Map<TDomainEntity>(inputEntity);
			//_entities.Entry(_entity).State = EntityState.Detached;
			_entities.Entry(entity).State = EntityState.Modified;

		}
	}
}
