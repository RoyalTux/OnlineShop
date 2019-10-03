namespace OnlineShop.BLL.Infrastructure.Account
{
	public class OperationDetails
	{
		public OperationDetails(bool succeeded, string message, string property)
		{
			this.Succeeded = succeeded;
			this.Message = message;
			this.Property = property;
		}

		private bool Succeeded { get; set; }

		private string Message { get; set; }

		private string Property { get; set; }
	}
}