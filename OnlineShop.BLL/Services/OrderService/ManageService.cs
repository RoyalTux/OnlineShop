using System;
using AutoMapper;
using OnlineShop.BLL.Dto;
using OnlineShop.BLL.Interfaces.OrderInterfaces;
using UnitOfWorkAndRepositories.Entites.Shop;
using UnitOfWorkAndRepositories.Interfaces.Shop;

namespace OnlineShop.BLL.Services.OrderService
{
	public class ManageService : IManageService
	{
		private readonly IShopUnitOfWork _db;

		private readonly IMapper _mapper;

		public ManageService(IShopUnitOfWork db, IMapper mapper)
		{
			this._db = db;
			this._mapper = mapper;
		}

		public void ConfirmOrder(int id)
		{
			OrderUnitOfWork order = this._db.Orders.GetById(id);
			order.State = StateUnitOfWork.Confirmed;
			this._db.Orders.Edit(order);
			this._db.Save();
		}

		public void DeclineOrder(int id)
		{
			OrderUnitOfWork order = this._db.Orders.GetById(id);
			order.State = StateUnitOfWork.Declined;
			this._db.Orders.Edit(order);
			this._db.Save();
		}

		public bool UpdateOrder(OrderDto orderDto)
		{
			try
			{
				OrderUnitOfWork order = this._mapper.Map<OrderUnitOfWork>(orderDto);
				this._db.Orders.Edit(order);
				this._db.Save();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public OrderDto GetOrder(int id)
		{
			return this._mapper.Map<OrderDto>(this._db.Orders.GetById(id));
		}
	}
}