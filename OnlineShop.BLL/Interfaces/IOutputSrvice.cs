using System.Collections.Generic;
using OnlineShop.BLL.Dto;

namespace OnlineShop.BLL.Interfaces
{
	interface IOutputSrvice
	{
		ItemFeaturesDto GetItemFeatures(int id);
		ItemDto GetItem(int id);

		IEnumerable<ItemDto> GetAllItems();
		IEnumerable<ItemDto> GetItemsWithPagination(int page, int pageSize);
		//IEnumerable<ItemDto> SortBy(BLLSortCriteria sortParam);
		//IEnumerable<ItemDto> SortByDescending(BLLSortCriteria sortParam);
		IEnumerable<ItemDto> Search(string request);
		IEnumerable<ItemDto> FilterByCategory(int categoryId);
		//IEnumerable<ItemDto> FilterByCriteria(FilterCriteries filter);
	}
}
