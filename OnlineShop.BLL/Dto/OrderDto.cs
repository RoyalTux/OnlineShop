using System;
using System.Collections.Generic;

namespace OnlineShop.BLL.Dto
{
	public class OrderDto
	{
		public int OrderId { get; set; }

		public DateTime Time { get; set; }

		public double Price { get; set; }

		public StateDto State { get; set; }

		public ICollection<ItemDto> Items { get; set; }

		public OrderDto()
		{
			Items = new List<ItemDto>();
		}
	}

	public enum StateDto
	{
		Confirmed,
		In_process,
		Declined
	}
}

