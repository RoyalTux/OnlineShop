using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities.Shop
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }

		[Required]
		[StringLength(30, MinimumLength = 5, ErrorMessage = "Invalid category name length")]
		public string CategoryName { get; set; }

		public ICollection<Item> Items { get; set; }

		public Category()
		{
			this.Items = new List<Item>();
		}
	}
}