using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Entities
{
	public class CategoryView
	{
		public int CategoryId { get; set; }

		[Required]
		[StringLength(30, MinimumLength = 5, ErrorMessage = "Invalid category name length")]
		public string CategoryName { get; set; }

		private ICollection<ItemView> Items { get; set; }

		public CategoryView()
		{
			Items = new List<ItemView>();
		}
	}
}