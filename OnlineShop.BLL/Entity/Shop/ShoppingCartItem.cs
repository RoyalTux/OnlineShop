using OnlineShop.BLL.Dto;

namespace OnlineShop.BLL.Entity.Shop
{
	class ShoppingCartItem
	{
		public int ShoppingCartId { get; set; }
		public ItemDto Item { get; set; }
		public int Quantity { get; set; }
	}
}
