namespace UnitOfWorkAndRepositories.Entites.Shop
{
	public class ItemFeatureUnitOfWork
	{
		public int ItemCharacteristicId { get; set; }

		public double Duration { get; set; }

		public int ReleaseYear { get; set; }

		public double FileSize { get; set; }

		public ItemUnitOfWork Item { get; set; }
	}
}
