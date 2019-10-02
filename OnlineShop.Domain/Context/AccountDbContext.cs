using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Domain.Entities.Account;

namespace OnlineShop.Domain.Context
{
	public class AccountDbContext : IdentityDbContext<ShopUser>
	{
		public AccountDbContext(string connectionString) : base(connectionString) { }

		public static DbSet<UserProfile> UserProfiles => null;
	}
}
