using System;
using AutoMapper;
using OnlineShop.BLL.Dto;
using OnlineShop.BLL.Interfaces;
using UnitOfWorkAndRepositories.Entites.Shop;
using UnitOfWorkAndRepositories.Interfaces.Shop;

namespace OnlineShop.BLL.Services
{
	public class AdminService : IAdminService
	{
		private readonly IShopUnitOfWork _db;
		private readonly IMapper _mapper;

		public AdminService(IShopUnitOfWork db, IMapper mapper)
		{
			this._db = db;
			this._mapper = mapper;
		}

		public bool AddCategory(CategoryDto categoryDto)
		{
			try
			{
				var category = _mapper.Map<CategoryUnitOfWork>(categoryDto);
				_db.Categories.Add(category);
				_db.Save();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public bool UpdateCategory(CategoryDto categoryDto)
		{
			try
			{
				var category = _mapper.Map<CategoryUnitOfWork>(categoryDto);
				_db.Categories.Edit(category);
				_db.Save();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public bool RemoveCategory(int id)
		{
			try
			{
				_db.Categories.DeleteById(id);
				_db.Save();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public bool AddItemFeatures(ItemFeaturesDto itemFeaturesDto)
		{
			try
			{
				var itemFeature = _mapper.Map<ItemFeatureUnitOfWork>(itemFeaturesDto);
				_db.ItemFeatures.Add(itemFeature);
				_db.Save();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public bool UpdateItemFeatures(ItemFeaturesDto itemFeaturesDto)
		{
			try
			{
				var itemFeature = _mapper.Map<ItemFeatureUnitOfWork>(itemFeaturesDto);
				_db.ItemFeatures.Edit(itemFeature);
				_db.Save();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public bool RemoveItemFeatures(int id)
		{
			try
			{
				_db.ItemFeatures.DeleteById(id);
				_db.Save();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public bool AddItem(ItemDto itemDto)
		{
			try
			{
				var item = _mapper.Map<ItemUnitOfWork>(itemDto);
				_db.Items.Add(item);
				_db.Save();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public bool UpdateItem(ItemDto itemDto)
		{
			try
			{
				var item = _mapper.Map<ItemUnitOfWork>(itemDto);
				_db.Items.Edit(item);
				_db.Save();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public bool RemoveItem(int id)
		{
			try
			{
				_db.Items.DeleteById(id);
				_db.Save();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public CategoryDto GetCategory(int id)
		{
			return _mapper.Map<CategoryDto>(_db.Categories.GetById(id));
		}

		public ItemFeaturesDto GetItemFeatures(int id)
		{
			return _mapper.Map<ItemFeaturesDto>(_db.ItemFeatures.GetById(id));
		}

		public ItemDto GetItem(int id)
		{
			return _mapper.Map<ItemDto>(_db.Items.GetById(id));
		}

		public OrderDto GetOrder(int id)
		{
			return _mapper.Map<OrderDto>(_db.Orders.GetById(id));
		}

		public void Dispose(bool disposing)
		{
			_db.Dispose();
		}
	}
}
