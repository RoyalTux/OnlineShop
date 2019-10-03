using System;
using System.Linq;
using AutoMapper;
using OnlineShop.BLL.Dto;
using OnlineShop.BLL.Entity.Shop;
using OnlineShop.BLL.Interfaces.OrderInterfaces;
using UnitOfWorkAndRepositories.Interfaces.Shop;

namespace OnlineShop.BLL.Services.OrderService
{
	public class UserService : IUserService
	{
		private readonly IShopUnitOfWork _db;

		private readonly IMapper _mapper;

		public UserService(IShopUnitOfWork db, IMapper mapper)
		{
			this._db = db;
			this._mapper = mapper;
		}

		public bool AddItem(ItemDto item, int quantity, IShoppingCart lineCollection)
		{
			try
			{
				if (item != null)
				{
					lineCollection.Items.Add(new ShoppingCartItem
					{
						Item = this._mapper.Map<ItemDto>(this._db.Items.GetById(item.ItemId)),
						Quantity = quantity
					});
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public bool RemoveItem(ItemDto item, IShoppingCart lineCollection)
		{
			try
			{
				lineCollection.Items.RemoveAll(l => l.Item.ItemId == item.ItemId);
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public bool Clear(IShoppingCart lineCollection)
		{
			try
			{
				lineCollection.Items.Clear();
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public IShoppingCart ComposeCart(IShoppingCart lineCollection)
		{
			double cartPrice = lineCollection.Items.Sum(item => item.Item.Price);

			ShoppingCart cart = new ShoppingCart
			{
				Items = lineCollection.Items,
				overallPrice = cartPrice
			};

			return cart;
		}

		public OrderDto MakeOrder(IShoppingCart cart)
		{
			System.Collections.Generic.List<ItemDto> items = cart.Items.Select(item => item.Item).ToList();

			OrderDto order = new OrderDto
			{
				Items = items,
				Time = DateTime.Now,
				Price = cart.overallPrice,
				State = StateDto.InProcess
			};
			return order;
		}
	}
}