using System.Collections.Generic;
using OnlineShop.Models.Entities;
using OnlineShop.Models.Shop.OutputService;

namespace OnlineShop.Models.Shop.UserService
{
	public class ItemsListViewModel
	{
		public IEnumerable<ItemView> Items { get; set; }
		public PagingInfo PagingInfo { get; set; }
	}
}