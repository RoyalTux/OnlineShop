using System;
using System.Collections.Generic;
using System.Security.Claims;
using UnitOfWorkAndRepositories.Entites.Account;
using UnitOfWorkAndRepositories.Identity;

namespace UnitOfWorkAndRepositories.Interfaces.Account
{
	public interface IAccountUnitOfWork : IDisposable
	{
		ShopUserManager UserManager { get; }

		IProfileManager ProfileManager { get; }

		ShopRoleManager RoleManager { get; }

		OperationDetailsUnitOfWork Create(UserModelUnitOfWork userDto);

		ClaimsIdentity Authenticate(UserModelUnitOfWork userDto);

		void SetInitialData(UserModelUnitOfWork adminDto, List<string> roles);

		void Save();
	}
}
