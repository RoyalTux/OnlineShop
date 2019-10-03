using OnlineShop.Domain.Context;
using OnlineShop.Domain.Entities.Account;
using UnitOfWorkAndRepositories.Entites.Account;
using UnitOfWorkAndRepositories.Interfaces.Account;

namespace UnitOfWorkAndRepositories.Realization.Repositories.Account
{
	public class ProfileManager : IProfileManager
	{
		private AccountDbContext Database { get; }

		public ProfileManager(AccountDbContext db)
		{
			this.Database = db;
		}

		public void Create(UserProfileUnitOfWork userProfile)
		{
			UserProfile profile = new UserProfile()
			{
				Id = userProfile.Id,
				Address = userProfile.Address,
				Name = userProfile.Name
			};
			AccountDbContext.UserProfiles.Add(profile);
			this.Database.SaveChanges();
		}

		public void Dispose()
		{
			this.Database.Dispose();
		}
	}
}