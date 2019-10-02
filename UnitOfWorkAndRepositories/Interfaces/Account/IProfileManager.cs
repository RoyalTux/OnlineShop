using System;
using UnitOfWorkAndRepositories.Entites.Account;

namespace UnitOfWorkAndRepositories.Interfaces.Account
{
	public interface IProfileManager : IDisposable
	{
		void Create(UserProfileUnitOfWork item);
	}
}
