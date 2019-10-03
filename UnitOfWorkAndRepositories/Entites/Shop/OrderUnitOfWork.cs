using System;
using System.Collections.Generic;

namespace UnitOfWorkAndRepositories.Entites.Shop
{
	public class OrderUnitOfWork
	{
		public int OrderId { get; set; }

		public DateTime Time { get; set; }

		public double Price { get; set; }

		public StateUnitOfWork State { get; set; }

		private ICollection<ItemUnitOfWork> Items { get; set; }

		public OrderUnitOfWork()
		{
			Items = new List<ItemUnitOfWork>();
		}
	}

	public enum StateUnitOfWork
	{
		Confirmed,
		InProcess,
		Declined
	}
}
