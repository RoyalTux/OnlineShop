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
			this.Bind<IShopUnitOfWork>().To<ShopUnitOfWork>().WithConstructorArgument("connectionString", this._shopConnectionString);
			this.Bind<IAccountUnitOfWork>().To<AccountUnitOfWork>().WithConstructorArgument("connectionString", this._accountConnectionString);
		}
	}
}