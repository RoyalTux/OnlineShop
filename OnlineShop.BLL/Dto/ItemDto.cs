using System.Collections.Generic;

namespace OnlineShop.BLL.Dto
{
	public class ItemDto
	{
		public int ItemId { get; set; }

		public string ItemName { get; set; }

		public string ItemPhotoPath { get; set; }

		public string Description { get; set; }

		public double Price { get; set; }

		public int Quantity { get; set; }

		public ItemFeaturesDto ItemFeatures { get; set; }

		public int? CategoryId { get; set; }

		public CategoryDto Category { get; set; }

		private ICollection<OrderDto> Orders { get; set; }

		public ItemDto()
		{
			Orders = new List<OrderDto>();
		}
	}
}
