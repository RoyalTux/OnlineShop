using OnlineShop.BLL.Dto;

namespace OnlineShop.BLL.Interfaces
{
	public interface IAdminService
	{
		bool AddCategory(CategoryDto categoryDto);

		bool UpdateCategory(CategoryDto categoryDto);

		bool RemoveCategory(int id);

		bool AddItemFeatures(ItemFeaturesDto itemFeaturesDto);

		bool UpdateItemFeatures(ItemFeaturesDto itemFeaturesDto);

		bool RemoveItemFeatures(int id);

		bool AddItem(ItemDto itemDto);

		bool UpdateItem(ItemDto itemDto);

		bool RemoveItem(int id);

		CategoryDto GetCategory(int id);

		ItemFeaturesDto GetItemFeatures(int id);

		ItemDto GetItem(int id);

		OrderDto GetOrder(int id);

		void Dispose(bool disposing);
	}
}