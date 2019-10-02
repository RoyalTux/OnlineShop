using OnlineShop.Models.Entities;

namespace OnlineShop.Models.Shop.UserService
{
	public class ShoppingCartItemView
	{
		public int ShoppingCartId { get; set; }
		public ItemView Item { get; set; }
		public int Quantity { get; set; }
	}
}