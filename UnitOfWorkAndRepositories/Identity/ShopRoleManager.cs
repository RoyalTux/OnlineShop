using Microsoft.AspNet.Identity;
using OnlineShop.Domain.Entities.Account;

namespace UnitOfWorkAndRepositories.Identity
{
	public class ShopRoleManager : RoleManager<ShopRole>
	{
		public ShopRoleManager(IRoleStore<ShopRole, string> store)
			: base(store)
		{ }
	}
}