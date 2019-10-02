using System.Collections.Generic;
using OnlineShop.BLL.Dto;

namespace OnlineShop.BLL.Interfaces
{
	public interface IOutputService
	{
		ItemFeaturesDto GetItemFeatures(int id);

		ItemDto GetItem(int id);

		IEnumerable<ItemDto> GetAllItems();

		IEnumerable<ItemDto> GetItemsWithPagination(int page, int pageSize);

		IEnumerable<ItemDto> Search(string request);
	}
}
