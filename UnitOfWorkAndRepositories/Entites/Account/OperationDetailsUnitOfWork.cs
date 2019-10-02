namespace UnitOfWorkAndRepositories.Entites.Account
{
	public class OperationDetailsUnitOfWork
	{
		public OperationDetailsUnitOfWork(bool succeeded, string message, string property)
		{
			this.Succeeded = succeeded;
			this.Message = message;
			this.Property = property;
		}

		public bool Succeeded { get; private set; }

		public string Message { get; private set; }

		public string Property { get; private set; }
	}
}