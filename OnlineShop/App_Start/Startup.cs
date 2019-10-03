using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using OnlineShop.BLL.Interfaces;
using OnlineShop.BLL.Services;
using Owin;

[assembly: OwinStartup(typeof(OnlineShop.App_Start.Startup))]

namespace OnlineShop.App_Start
{
	public class Startup
	{
		private readonly IAccountServiceCreator _serviceCreator = new AccountServiceCreator();

		public void Configuration(IAppBuilder app)
		{
			app.CreatePerOwinContext(this.CreateAccountService);
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Account/Login"),
			});
		}

		private IAccountService CreateAccountService()
		{
			return this._serviceCreator.CreateAccountService("AccountConnection");
		}
	}
}