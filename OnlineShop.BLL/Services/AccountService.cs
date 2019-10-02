using System.Collections.Generic;
using System.Security.Claims;
using OnlineShop.BLL.Dto;
using OnlineShop.BLL.Infrastructure.Account;
using OnlineShop.BLL.Interfaces;
using UnitOfWorkAndRepositories.Entites.Account;
using UnitOfWorkAndRepositories.Interfaces.Account;

namespace OnlineShop.BLL.Services
{
	public class AccountService : IAccountService
	{
		private IAccountUnitOfWork Database { get; set; }

		public AccountService(IAccountUnitOfWork uow)
		{
			Database = uow;
		}

		public OperationDetails Create(UserDto userDto)
		{
			var userUnitOfWork = new UserModelUnitOfWork()
			{
				Email = userDto.Email,
				Password = userDto.Password,
				UserName = userDto.UserName,
				Name = userDto.Name,
				Address = userDto.Address,
				Role = userDto.Role
			};
			var operationDetailsUnitOfWork = Database.Create(userUnitOfWork);
			var operationDetails = new OperationDetails(operationDetailsUnitOfWork.Succeeded,
				operationDetailsUnitOfWork.Message, operationDetailsUnitOfWork.Property);

			return operationDetails;
		}

		public ClaimsIdentity Authenticate(UserDto userDto)
		{
			var userUoW = new UserModelUnitOfWork()
			{
				Email = userDto.Email,
				Password = userDto.Password,
				UserName = userDto.UserName,
				Name = userDto.Name,
				Address = userDto.Address,
				Role = userDto.Role
			};
			return Database.Authenticate(userUoW);
		}

		public void SetInitialData(UserDto adminDto, List<string> roles)
		{
			var admin = new UserModelUnitOfWork()
			{
				Email = adminDto.Email,
				Password = adminDto.Password,
				UserName = adminDto.UserName,
				Name = adminDto.Name,
				Address = adminDto.Address,
				Role = adminDto.Role
			};
			Database.SetInitialData(admin, roles);
		}

		public void Dispose()
		{
			Database.Dispose();
		}

	}
}
