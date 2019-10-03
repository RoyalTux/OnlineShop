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
				CategoryUnitOfWork category = this._mapper.Map<CategoryUnitOfWork>(categoryDto);
				this._db.Categories.Add(category);
				this._db.Save();
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
				CategoryUnitOfWork category = this._mapper.Map<CategoryUnitOfWork>(categoryDto);
				this._db.Categories.Edit(category);
				this._db.Save();
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
				this._db.Categories.DeleteById(id);
				this._db.Save();
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
				ItemFeatureUnitOfWork itemFeature = this._mapper.Map<ItemFeatureUnitOfWork>(itemFeaturesDto);
				this._db.ItemFeatures.Add(itemFeature);
				this._db.Save();
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
				ItemFeatureUnitOfWork itemFeature = this._mapper.Map<ItemFeatureUnitOfWork>(itemFeaturesDto);
				this._db.ItemFeatures.Edit(itemFeature);
				this._db.Save();
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
				this._db.ItemFeatures.DeleteById(id);
				this._db.Save();
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
				ItemUnitOfWork item = this._mapper.Map<ItemUnitOfWork>(itemDto);
				this._db.Items.Add(item);
				this._db.Save();
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
				ItemUnitOfWork item = this._mapper.Map<ItemUnitOfWork>(itemDto);
				this._db.Items.Edit(item);
				this._db.Save();
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
				this._db.Items.DeleteById(id);
				this._db.Save();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public CategoryDto GetCategory(int id)
		{
			return this._mapper.Map<CategoryDto>(this._db.Categories.GetById(id));
		}

		public ItemFeaturesDto GetItemFeatures(int id)
		{
			return this._mapper.Map<ItemFeaturesDto>(this._db.ItemFeatures.GetById(id));
		}

		public ItemDto GetItem(int id)
		{
			return this._mapper.Map<ItemDto>(this._db.Items.GetById(id));
		}

		public OrderDto GetOrder(int id)
		{
			return this._mapper.Map<OrderDto>(this._db.Orders.GetById(id));
		}

		public void Dispose(bool disposing)
		{
			this._db.Dispose();
		}
	}
}