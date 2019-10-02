using Ninject.Modules;

namespace OnlineShop.Infrastructure
{
	public class WebApiNinjectModule : NinjectModule
	{
		public override void Load()
		{
			//Bind<IShoppingCart>().To<ShoppingCart>().InSingletonScope();
		}
	}
}