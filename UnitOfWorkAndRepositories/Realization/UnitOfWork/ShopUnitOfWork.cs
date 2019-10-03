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
			_dbContext = new EfShopContext(connectionString);
			_mapper = mapper;
		}

		public ICategoryRepository Categories =>
			_categoryRepository ?? (_categoryRepository = new CategoryRepository(_dbContext, _mapper));

		public IItemFeatureRepository ItemFeatures =>
			_itemFeatureRepository ?? (_itemFeatureRepository = new ItemFeatureRepository(_dbContext, _mapper));

		public IItemRepository Items =>
			_itemRepository ?? (_itemRepository = new ItemRepository(_dbContext, _mapper));

		public IOrderRepository Orders =>
			_orderRepository ?? (_orderRepository = new OrderRepository(_dbContext, _mapper));

		public int Save()
		{
			return _dbContext.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private bool _disposed;

		private void Dispose(bool disposing)
		{
			if (!this._disposed)
				if (disposing)
				{
					_dbContext?.Dispose();
				}
			this._disposed = true;
		}
	}
}
