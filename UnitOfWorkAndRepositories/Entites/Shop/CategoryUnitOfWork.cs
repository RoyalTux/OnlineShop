using System.Collections.Generic;

namespace UnitOfWorkAndRepositories.Entites.Shop
{
	public class CategoryUnitOfWork
	{
		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		private ICollection<ItemUnitOfWork> Items { get; set; }

		public CategoryUnitOfWork()
		{
			this.Items = new List<ItemUnitOfWork>();
		}
	}
}