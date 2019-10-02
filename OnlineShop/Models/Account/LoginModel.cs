using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Account
{
	public class LoginModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}