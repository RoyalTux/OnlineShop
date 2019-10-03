using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Shop.OutputService
{
	public class PagingInfo
	{
		[Required]
		public int TotalItems { get; set; }

		[Required]
		[Range(4, 10, ErrorMessage = "Incorrect number of items per page")]
		public int ItemsPerPage { get; set; }

		[Required]
		[RegularExpression(@"[1-9]([0-9])*", ErrorMessage = "Invalid page number")]
		public int CurrentPage { get; set; }

		public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
	}
}