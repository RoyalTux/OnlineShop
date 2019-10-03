using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Account
{
	public class RegistrationModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }

		[Required]
		public string Address { get; set; }

		[Required]
		public string Name { get; set; }
	}
}