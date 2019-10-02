using System;

namespace UnitOfWorkAndRepositories.Interfaces.Shop
{
	public interface IShopUnitOfWork : IDisposable
	{
		ICategoryRepository Categories { get; }

		IItemFeatureRepository ItemFeatures { get; }

		IItemRepository Items { get; }

		IOrderRepository Orders { get; }

		int Save();
	}
}
