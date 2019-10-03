using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OnlineShop.BLL.Dto;
using OnlineShop.BLL.Infrastructure.Account;
using OnlineShop.BLL.Interfaces;
using OnlineShop.Models.Account;

namespace OnlineShop.Controllers
{
	public class AccountController : ApiController
	{
		private static IAccountService AccountService => HttpContext.Current.GetOwinContext().GetUserManager<IAccountService>();

		private static IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;

		[HttpGet]
		[Route("api/Account/Login")]
		public IHttpActionResult Login([FromUri]LoginModel model)
		{
			SetInitialData();
			if (!this.ModelState.IsValid)
			{
				return this.BadRequest();
			}

			UserDto userDto = new UserDto { Email = model.Email, Password = model.Password };
			System.Security.Claims.ClaimsIdentity claim = AccountService.Authenticate(userDto);
			if (claim == null)
			{
				return this.Ok("Wrong login or password.");
			}
			AuthenticationManager.SignOut();
			AuthenticationManager.SignIn(new AuthenticationProperties
			{
				IsPersistent = true
			}, claim);
			return this.Ok("Log in success.");
		}

		[HttpPost]
		[Route("api/Account/Logout")]
		public IHttpActionResult Logout()
		{
			AuthenticationManager.SignOut();
			return this.Ok();
		}

		[HttpGet]
		[Route("api/Account/Register")]
		public IHttpActionResult Register([FromUri]RegistrationModel model)
		{
			SetInitialData();
			OperationDetails operationDetails;
			if (!this.ModelState.IsValid)
			{
				return this.BadRequest();
			}

			UserDto userDto = new UserDto
			{
				Email = model.Email,
				Password = model.Password,
				Address = model.Address,
				UserName = model.Name,
				Name = model.Name,
				Role = "user"
			};
			operationDetails = AccountService.Create(userDto);
			return this.Ok(operationDetails);
		}

		private static void SetInitialData()
		{
			AccountService.SetInitialData(new UserDto
			{
				Email = "admin@gmail.com",
				UserName = "admin@gmail.com",
				Password = "admin12345",
				Name = "Admin Admin",
				Address = "test street",
				Role = "admin",
			}, new List<string> { "user", "admin", "manager" });

			AccountService.SetInitialData(new UserDto
			{
				Email = "user@gmail.com",
				UserName = "user@gmail.com",
				Password = "user12345",
				Name = "User User",
				Address = "test street",
				Role = "user",
			}, new List<string> { "user", "admin", "manager" });
		}
	}
}