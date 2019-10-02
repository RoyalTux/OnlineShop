using OnlineShop.Domain.Context;
using OnlineShop.Domain.Entities.Account;
using UnitOfWorkAndRepositories.Entites.Account;
using UnitOfWorkAndRepositories.Interfaces.Account;

namespace UnitOfWorkAndRepositories.Realization.Repositories.Account
{
	public class ProfileManager : IProfileManager
	{
		public AccountDbContext Database { get; set; }

		public ProfileManager(AccountDbContext db)
		{
			Database = db;
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
			Database.SaveChanges();
		}

		public void Dispose()
		{
			Database.Dispose();
		}
	}
}
