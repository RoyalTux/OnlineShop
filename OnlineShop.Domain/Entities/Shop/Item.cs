using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities.Shop
{
	public class Item
	{
		[Key]
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

		[Range(1, 100, ErrorMessage = "Incorrect quantity of goods")]
		public int Quantity { get; set; }

		public ItemFeatures ItemFeature { get; set; }

		[Column("CategoryId")]
		public int? CategoryId { get; set; }

		public Category Category { get; set; }

		public ICollection<Order> Orders { get; set; }

		public Item()
		{
			this.Orders = new List<Order>();
		}
	}
}