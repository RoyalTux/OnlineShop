using OnlineShop.BLL.Interfaces;
using UnitOfWorkAndRepositories.Realization.UnitOfWork;

namespace OnlineShop.BLL.Services
{
	public class AccountServiceCreator : IAccountServiceCreator
	{
		public IAccountService CreateAccountService(string connection)
		{
			return new AccountService(new AccountUnitOfWork(connection));
		}
	}
}
