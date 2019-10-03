using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Entities
{
	public class OrderView
	{

		public int OrderId { get; set; }

		[Required]
		public DateTime Time { get; set; }

		[Required]
		public double Price { get; set; }

		[Required]
		public StateView State { get; set; }

		private ICollection<ItemView> Items { get; set; }

		public OrderView()
		{
			Items = new List<ItemView>();
		}
	}
	public enum StateView
	{
		Confirmed,
		InProcess,
		Declined
	}
}