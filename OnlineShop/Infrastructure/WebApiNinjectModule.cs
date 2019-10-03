using Ninject.Modules;
using OnlineShop.BLL.Entity.Shop;
using OnlineShop.BLL.Interfaces.OrderInterfaces;

namespace OnlineShop.Infrastructure
{
	public class WebApiNinjectModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<IShoppingCart>().To<ShoppingCart>().InSingletonScope();
		}
	}
}