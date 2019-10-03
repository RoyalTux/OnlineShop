using Microsoft.AspNet.Identity;
using OnlineShop.Domain.Entities.Account;

namespace UnitOfWorkAndRepositories.Identity
{
	public class ShopUserManager : UserManager<ShopUser>
	{
		public ShopUserManager(IUserStore<ShopUser> store)
			: base(store)
		{
		}
	}
}