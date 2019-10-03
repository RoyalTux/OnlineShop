namespace UnitOfWorkAndRepositories.Entites.Account
{
	public class UserProfileUnitOfWork
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Address { get; set; }

		public UserUnitOfWork ShopUser { get; set; }
	}
}