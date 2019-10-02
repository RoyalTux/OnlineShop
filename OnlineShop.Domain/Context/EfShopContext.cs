using System.Data.Entity;
using OnlineShop.Domain.Entities.Shop;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Domain.Context
{
	public class EfShopContext : DbContext, IEfShopContext
	{
		static EfShopContext()
		{
			Database.SetInitializer<EfShopContext>(new DropCreateDatabaseIfModelChanges<EfShopContext>());
		}

		public EfShopContext(string connectionString)
			: base(connectionString)
		{ }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>()
				.HasMany(p => p.Items)
				.WithMany(c => c.Orders)
				.Map(m =>
				{
					m.ToTable("ItemOrders");
					m.MapLeftKey("OrderId");
					m.MapRightKey("ItemId");
				});

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<ItemFeatures> ItemFeatures { get; set; }
	}
}
