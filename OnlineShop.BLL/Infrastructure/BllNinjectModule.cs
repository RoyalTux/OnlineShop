using Ninject.Modules;
using OnlineShop.BLL.Entity.Shop;
using OnlineShop.BLL.Interfaces;
using OnlineShop.BLL.Interfaces.OrderInterfaces;
using OnlineShop.BLL.Services;
using OnlineShop.BLL.Services.OrderService;

namespace OnlineShop.BLL.Infrastructure
{
	public class BllNinjectModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<IAdminService>().To<AdminService>();
			this.Bind<IUserService>().To<UserService>().InSingletonScope();
			this.Bind<IManageService>().To<ManageService>();
			this.Bind<IShoppingCart>().To<ShoppingCart>().InSingletonScope();
			this.Bind<IOutputService>().To<OutputService>();
			this.Bind<IAccountService>().To<AccountService>();
		}
	}
}