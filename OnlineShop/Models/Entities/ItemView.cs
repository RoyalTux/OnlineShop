using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Entities
{
	public class ItemView
	{
		public int ItemId { get; set; }

		[Required]
		[StringLength(30, MinimumLength = 5, ErrorMessage = "Invalid product name length")]
		public string ItemName { get; set; }

		public string ItemPhotoPath { get; set; }

		[Required]
		[StringLength(250, MinimumLength = 30, ErrorMessage = "Invalid product description length")]
		public string Description { get; set; }

		[Required]
		public double Price { get; set; }

		[Required]
		[Range(1, 100, ErrorMessage = "Incorrect quantity of goods")]
		public int Quantity { get; set; }

		public ItemFeaturesView ItemFeatures { get; set; }

		public int? CategoryId { get; set; }
		public CategoryView Category { get; set; }

		private ICollection<OrderView> Orders { get; set; }

		public ItemView()
		{
			this.Orders = new List<OrderView>();
		}
	}
}