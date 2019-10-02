using Ninject.Modules;
using UnitOfWorkAndRepositories.Interfaces.Account;
using UnitOfWorkAndRepositories.Interfaces.Shop;
using UnitOfWorkAndRepositories.Realization.UnitOfWork;

namespace UnitOfWorkAndRepositories.Infrastructure
{
	public class UnitOfWorkNinjectModule : NinjectModule
	{
		private readonly string _shopConnectionString;
		private readonly string _accountConnectionString;


		public UnitOfWorkNinjectModule(string shopConnectionString, string accountConnectionString)
		{
			this._shopConnectionString = shopConnectionString;
			this._accountConnectionString = accountConnectionString;
		}

		public override void Load()
		{
			Bind<IShopUnitOfWork>().To<ShopUnitOfWork>().WithConstructorArgument("connectionString", _shopConnectionString);
			Bind<IAccountUnitOfWork>().To<AccountUnitOfWork>().WithConstructorArgument("connectionString", _accountConnectionString);
		}
	}
}
