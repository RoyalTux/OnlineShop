using System.Collections.Generic;

namespace UnitOfWorkAndRepositories.Entites.Shop
{
	public class ItemUnitOfWork
	{
		public int ItemId { get; set; }

		public string ItemName { get; set; }

		public string ItemPhotoPath { get; set; }

		public string Description { get; set; }

		public double Price { get; set; }

		public int Quantity { get; set; }

		public ItemFeatureUnitOfWork ItemCharacteristic { get; set; }


		public int? CategoryId { get; set; }

		public CategoryUnitOfWork Category { get; set; }

		private ICollection<OrderUnitOfWork> Orders { get; set; }

		public ItemUnitOfWork()
		{
			Orders = new List<OrderUnitOfWork>();
		}
	}
}
