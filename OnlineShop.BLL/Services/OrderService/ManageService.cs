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
			var order = _db.Orders.GetById(id);
			order.State = StateUnitOfWork.Confirmed;
			_db.Orders.Edit(order);
			_db.Save();
		}

		public void DeclineOrder(int id)
		{
			var order = _db.Orders.GetById(id);
			order.State = StateUnitOfWork.Declined;
			_db.Orders.Edit(order);
			_db.Save();
		}

		public bool UpdateOrder(OrderDto orderDto)
		{
			try
			{
				var order = _mapper.Map<OrderUnitOfWork>(orderDto);
				_db.Orders.Edit(order);
				_db.Save();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public OrderDto GetOrder(int id)
		{
			return _mapper.Map<OrderDto>(_db.Orders.GetById(id));
		}
	}
}
