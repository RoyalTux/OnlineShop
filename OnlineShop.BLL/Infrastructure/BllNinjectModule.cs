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
			Bind<IAdminService>().To<AdminService>();
			Bind<IUserService>().To<UserService>().InSingletonScope();
			Bind<IManageService>().To<ManageService>();
			Bind<IShoppingCart>().To<ShoppingCart>().InSingletonScope();
			Bind<IOutputService>().To<OutputService>();
			Bind<IAccountService>().To<AccountService>();
		}
	}
}
