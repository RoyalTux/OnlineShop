using System.Collections.Generic;
using OnlineShop.BLL.Interfaces.OrderInterfaces;

namespace OnlineShop.BLL.Entity.Shop
{
	class ShoppingCart : IShoppingCart
	{
		public ShoppingCart()
		{
			Items = new List<ShoppingCartItem>();
		}

		public List<ShoppingCartItem> Items { get; set; }
		public double overallPrice { get; set; }
	}
}
