using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineShop.Domain.Entities.Account
{
	public class ShopUser : IdentityUser
	{
		public UserProfile UserProfile { get; set; }
	}
}