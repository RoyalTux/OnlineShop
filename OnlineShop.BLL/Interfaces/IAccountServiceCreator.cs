namespace OnlineShop.BLL.Interfaces
{
	interface IAccountServiceCreator
	{
		IAccountService CreateAccountService(string connection);
	}
}
