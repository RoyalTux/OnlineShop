using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities.Account
{
	public class UserProfile
	{
		[Key]
		[ForeignKey("ShopUser")]
		public string Id { get; set; }

		public string Name { get; set; }
		public string Address { get; set; }

		public virtual ShopUser ShopUser { get; set; }
	}
}