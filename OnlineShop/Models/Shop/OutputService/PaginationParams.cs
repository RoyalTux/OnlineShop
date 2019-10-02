using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Shop.OutputService
{
	public class PaginationParams
	{
		[Required]
		[RegularExpression(@"[1-9]([0-9])*", ErrorMessage = "Invalid page number")]
		public int CurrentPage { get; set; }

		[Required]
		[Range(4, 10, ErrorMessage = "Incorrect number of items per page")]
		public int PageSize { get; set; }
	}
}