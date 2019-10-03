using System;
using System.Collections.Generic;
using System.Security.Claims;
using OnlineShop.BLL.Dto;
using OnlineShop.BLL.Infrastructure.Account;

namespace OnlineShop.BLL.Interfaces
{
	public interface IAccountService : IDisposable
	{
		OperationDetails Create(UserDto userDto);
		ClaimsIdentity Authenticate(UserDto userDto);
		void SetInitialData(UserDto adminDto, List<string> roles);
	}
}
