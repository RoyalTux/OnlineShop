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
			this._entities = context;
			this.Dbset = this._entities.Set<TDomainEntity>();
			this.Mapper = mapper;
		}

		public virtual IEnumerable<TInputEntity> GetAll()
		{
			return this.Mapper.Map<IEnumerable<TInputEntity>>(this.Dbset.AsEnumerable<TDomainEntity>());
		}

		public virtual void Add(TInputEntity inputEntity)
		{
			TDomainEntity entity = this.Mapper.Map<TDomainEntity>(inputEntity);
			this.Dbset.Add(entity);
		}

		public virtual void Delete(TInputEntity inputEntity)
		{
			TDomainEntity entity = this.Mapper.Map<TDomainEntity>(inputEntity);
			this.Dbset.Remove(entity);
		}

		public virtual void DeleteById(int id)
		{
			TDomainEntity findEntity = this.Dbset.Find(id);
			this.Dbset.Remove(findEntity);
			TInputEntity entity = this.Mapper.Map<TInputEntity>(findEntity);
		}

		public virtual void Edit(TInputEntity inputEntity)
		{
			TDomainEntity entity = this.Mapper.Map<TDomainEntity>(inputEntity);
			//_entities.Entry(_entity).State = EntityState.Detached;
			this._entities.Entry(entity).State = EntityState.Modified;
		}
	}
}