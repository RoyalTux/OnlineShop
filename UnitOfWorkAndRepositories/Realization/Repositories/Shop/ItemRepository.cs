﻿using System.Data.Entity;
using System.Linq;
using AutoMapper;
using OnlineShop.Domain.Entities.Shop;
using OnlineShop.Domain.Interfaces;
using UnitOfWorkAndRepositories.Entites.Shop;
using UnitOfWorkAndRepositories.Interfaces.Shop;

namespace UnitOfWorkAndRepositories.Realization.Repositories.Shop
{
	public class ItemRepository : ShopGenericRepository<ItemUnitOfWork, Item>, IItemRepository
	{
		public ItemRepository(IEfShopContext context, IMapper mapper)
			: base(context, mapper)
		{ }

		public ItemUnitOfWork GetById(int id)
		{
			ItemUnitOfWork entity = this.Mapper.Map<ItemUnitOfWork>(this.Dbset.Include(x => x.ItemFeature).FirstOrDefault(x => x.ItemId == id));
			return entity;
		}
	}
}