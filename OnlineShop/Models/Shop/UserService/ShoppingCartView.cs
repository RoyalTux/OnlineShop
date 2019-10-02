using System.Collections.Generic;

namespace OnlineShop.Models.Shop.UserService
{
	public class ShoppingCartView
	{
		public ShoppingCartView()
		{
			items = new List<ShoppingCartItemView>();
		}
		public List<ShoppingCartItemView> items { get; set; }
		public double overallPrice { get; set; }
	}
}