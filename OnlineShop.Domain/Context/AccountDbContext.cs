using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Domain.Entities.Account;

namespace OnlineShop.Domain.Context
{
	public class AccountDbContext : IdentityDbContext<ShopUser>
	{
		public AccountDbContext(string conectionString) : base(conectionString) { }

		public DbSet<UserProfile> UserProfiles { get; set; }
	}
}
