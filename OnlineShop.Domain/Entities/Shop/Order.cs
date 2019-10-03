using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities.Shop
{
	public class Order
	{
		[Key]
		public int OrderId { get; set; }

		[Required]
		public DateTime Time { get; set; }

		[Required]
		public double Price { get; set; }

		[Required]
		public State State { get; set; }

		public ICollection<Item> Items { get; set; }

		public Order()
		{
			this.Items = new List<Item>();
		}
	}

	public enum State
	{
		Confirmed,
		InProcess,
		Declined
	}
}