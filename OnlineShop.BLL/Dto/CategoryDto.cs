using System.Collections.Generic;

namespace OnlineShop.BLL.Dto
{
	public class CategoryDto
	{
		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		private ICollection<ItemDto> Items { get; set; }

		public CategoryDto()
		{
			this.Items = new List<ItemDto>();
		}
	}
}