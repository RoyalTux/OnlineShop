using System.Collections.Generic;
using OnlineShop.BLL.Entity.Shop;

namespace OnlineShop.BLL.Interfaces.OrderInterfaces
{
	public interface IShoppingCart
	{
		List<ShoppingCartItem> Items { get; set; }
		double overallPrice { get; set; }
	}
}
