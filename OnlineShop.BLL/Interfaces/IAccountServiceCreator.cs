namespace OnlineShop.BLL.Interfaces
{
	public interface IAccountServiceCreator
	{
		IAccountService CreateAccountService(string connection);
	}
}