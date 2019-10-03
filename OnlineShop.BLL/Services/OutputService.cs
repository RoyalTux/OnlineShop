using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using OnlineShop.BLL.Dto;
using OnlineShop.BLL.Interfaces;
using UnitOfWorkAndRepositories.Interfaces.Shop;

namespace OnlineShop.BLL.Services
{
	public class OutputService : IOutputService
	{
		private readonly IShopUnitOfWork _db;
		private readonly IMapper _mapper;

		public OutputService(IShopUnitOfWork db, IMapper mapper)
		{
			this._db = db;
			this._mapper = mapper;
		}

		public ItemFeaturesDto GetItemFeatures(int id)
		{
			return this._mapper.Map<ItemFeaturesDto>(this._db.ItemFeatures.GetById(id));
		}

		public ItemDto GetItem(int id)
		{
			return this._mapper.Map<ItemDto>(this._db.Items.GetById(id));
		}

		public IEnumerable<ItemDto> GetAllItems()
		{
			return this._mapper.Map<IEnumerable<ItemDto>>(this._db.Items.GetAll());
		}

		public IEnumerable<ItemDto> GetItemsWithPagination(int page, int pageSize)
		{
			IEnumerable<UnitOfWorkAndRepositories.Entites.Shop.ItemUnitOfWork> itemsUnitOfWork = this._db.Items.GetAll()
					 .OrderBy(item => item.ItemId)
					 .Skip((page - 1) * pageSize)
					 .Take(pageSize);

			return this._mapper.Map<IEnumerable<ItemDto>>(itemsUnitOfWork);
		}

		public IEnumerable<ItemDto> Search(string request)
		{
			IEnumerable<ItemDto> allItems = this.GetAllItems();

			return allItems.Where(item => item.ItemName.ToLower().Contains(request.ToLower()));
		}

		private int GetDefaultMinPrice(IEnumerable<ItemDto> items)
		{
			return (int)items.Min(x => x.Price);
		}

		private int GetDefaultMaxPrice(IEnumerable<ItemDto> items)
		{
			return (int)items.Max(x => x.Price);
		}
	}
}