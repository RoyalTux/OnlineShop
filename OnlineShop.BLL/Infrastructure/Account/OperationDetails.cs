namespace OnlineShop.BLL.Infrastructure.Account
{
	public class OperationDetails
	{
		public OperationDetails(bool succeeded, string message, string property)
		{
			Succeeded = succeeded;
			Message = message;
			Property = property;
		}

		private bool Succeeded { get; set; }

		private string Message { get; set; }

		private string Property { get; set; }
	}
}
