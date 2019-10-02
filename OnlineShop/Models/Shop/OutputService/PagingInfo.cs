﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Shop.OutputService
{
	public class PagingInfo
	{
		[Required]
		public int TotalItems { get; set; } //Count of Items

		[Required]
		[Range(4, 10, ErrorMessage = "Incorrect number of items per page")]
		public int ItemsPerPage { get; set; } //Count of items on one page

		[Required]
		[RegularExpression(@"[1-9]([0-9])*", ErrorMessage = "Invalid page number")]
		public int CurrentPage { get; set; } // number of current page

		public int TotalPages //Count of all pages
		{
			get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
		}
	}
}