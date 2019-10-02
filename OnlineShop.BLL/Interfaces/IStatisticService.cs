using System.Collections.Generic;
using OnlineShop.BLL.Dto;

namespace OnlineShop.BLL.Interfaces
{
	interface IStatisticService
	{
		IEnumerable<OrderDto> getAllOrders();
		//Statistic getOverallStats();
		IEnumerable<ItemDto> getAllItems();
	}
}
