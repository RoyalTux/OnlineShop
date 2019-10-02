using System.Collections.Generic;

namespace OnlineShop.Models.Shop.UserService
{
	public interface IShoppingCartView
	{
		List<ShoppingCartItemView> items { get; set; }
		double overallPrice { get; set; }
	}
}