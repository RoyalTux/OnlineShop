using System.Collections.Generic;

namespace OnlineShop.BLL.Dto
{
	public class CategoryDto
	{
		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		public ICollection<ItemDto> Items { get; set; }

		public CategoryDto()
		{
			Items = new List<ItemDto>();
		}
	}
}
