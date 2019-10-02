using OnlineShop.BLL.Dto;

namespace OnlineShop.BLL.Interfaces.OrderInterfaces
{
	public interface IManageService
	{
		void ConfirmOrder(int id);
		void DeclineOrder(int id);
		bool UpdateOrder(OrderDto order);
		OrderDto GetOrder(int id);
	}
}
