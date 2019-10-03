using System;
using AutoMapper;
using OnlineShop.Domain.Context;
using OnlineShop.Domain.Interfaces;
using UnitOfWorkAndRepositories.Interfaces.Shop;
using UnitOfWorkAndRepositories.Realization.Repositories.Shop;

namespace UnitOfWorkAndRepositories.Realization.UnitOfWork
{
	public class ShopUnitOfWork : IShopUnitOfWork
	{
		private readonly IEfShopContext _dbContext;
		private readonly IMapper _mapper;

		private ICategoryRepository _categoryRepository;
		private IItemFeatureRepository _itemFeatureRepository;
		private IItemRepository _itemRepository;
		private IOrderRepository _orderRepository;

		public ShopUnitOfWork(string connectionString, IMapper mapper)
		{
			this._dbContext = new EfShopContext(connectionString);
			this._mapper = mapper;
		}

		public ICategoryRepository Categories =>
			this._categoryRepository ?? (this._categoryRepository = new CategoryRepository(this._dbContext, this._mapper));

		public IItemFeatureRepository ItemFeatures =>
			this._itemFeatureRepository ?? (this._itemFeatureRepository = new ItemFeatureRepository(this._dbContext, this._mapper));

		public IItemRepository Items =>
			this._itemRepository ?? (this._itemRepository = new ItemRepository(this._dbContext, this._mapper));

		public IOrderRepository Orders =>
			this._orderRepository ?? (this._orderRepository = new OrderRepository(this._dbContext, this._mapper));

		public int Save()
		{
			return this._dbContext.SaveChanges();
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		private bool _disposed;

		private void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					this._dbContext?.Dispose();
				}
			}

			this._disposed = true;
		}
	}
}