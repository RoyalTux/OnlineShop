using OnlineShop.BLL.Dto;

namespace OnlineShop.BLL.Interfaces.OrderInterfaces
{
	interface IUserService
	{
		bool AddItem(ItemDto item, int quantity, IShoppingCart itemCollection);
		bool RemoveItem(ItemDto item, IShoppingCart itemCollection);
		bool Clear(IShoppingCart itemCollection);
		IShoppingCart ComposeCart(IShoppingCart itemCollection);
		OrderDto MakeOrder(IShoppingCart cart);
	}
}
