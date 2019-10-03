using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Domain.Context;
using OnlineShop.Domain.Entities.Account;
using UnitOfWorkAndRepositories.Entites.Account;
using UnitOfWorkAndRepositories.Identity;
using UnitOfWorkAndRepositories.Interfaces.Account;
using UnitOfWorkAndRepositories.Realization.Repositories.Account;

namespace UnitOfWorkAndRepositories.Realization.UnitOfWork
{
	public sealed class AccountUnitOfWork : IAccountUnitOfWork
	{
		private readonly AccountDbContext _db;

		public AccountUnitOfWork(string connectionString)
		{
			this._db = new AccountDbContext(connectionString);
			this.UserManager = new ShopUserManager(new UserStore<ShopUser>(this._db));
			this.RoleManager = new ShopRoleManager(new RoleStore<ShopRole>(this._db));
			this.ProfileManager = new ProfileManager(this._db);
		}

		public ShopUserManager UserManager { get; }

		public IProfileManager ProfileManager { get; }

		public ShopRoleManager RoleManager { get; }

		public OperationDetailsUnitOfWork Create(UserModelUnitOfWork userDto)
		{
			var user = this.UserManager.FindByEmail(userDto.Email);
			if (user == null)
			{
				user = new ShopUser { Email = userDto.Email, UserName = userDto.Email };
				var result = this.UserManager.Create(user, userDto.Password);
				if (result.Errors.Any())
				{
					return new OperationDetailsUnitOfWork(false, result.Errors.FirstOrDefault(), "");
				}

				this.UserManager.AddToRole(user.Id, userDto.Role);

				var clientProfile = new UserProfileUnitOfWork { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
				this.ProfileManager.Create(clientProfile);
				this.Save();
				return new OperationDetailsUnitOfWork(true, "Registration completed successfully", "");
			}
			else
			{
				return new OperationDetailsUnitOfWork(false, "A user with this login already exists", "Email");
			}
		}

		public ClaimsIdentity Authenticate(UserModelUnitOfWork userDto)
		{
			ClaimsIdentity claim = null;

			var user = this.UserManager.Find(userDto.Email, userDto.Password);

			if (user != null)
			{
				claim = this.UserManager.CreateIdentity(user,
											DefaultAuthenticationTypes.ApplicationCookie);
			}

			return claim;
		}

		public void SetInitialData(UserModelUnitOfWork adminDto, List<string> roles)
		{
			foreach (var role in from roleName in roles let role = this.RoleManager.FindByName(roleName)
				where role == null select new ShopRole { Name = roleName })
			{
				RoleManager.Create(role);
			}

			Create(adminDto);
		}

		public void Save()
		{
			this._db.SaveChanges();
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		private bool _disposed;

		private void Dispose(bool disposing)
		{
			if (_disposed) return;
			if (disposing)
			{
				this.UserManager.Dispose();
				this.RoleManager.Dispose();
				this.ProfileManager.Dispose();
			}
			this._disposed = true;
		}
	}
}