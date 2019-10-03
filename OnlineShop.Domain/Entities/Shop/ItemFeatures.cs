using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Entities.Shop
{
	public class ItemFeatures
	{
		[Key]
		[ForeignKey("Item")]
		public int ItemFeatureId { get; set; }

		[Required]
		public double Duration { get; set; }

		[Required]
		public int ReleaseYear { get; set; }

		[Required]
		public double FileSize { get; set; }

		public Item Item { get; set; }
	}
}