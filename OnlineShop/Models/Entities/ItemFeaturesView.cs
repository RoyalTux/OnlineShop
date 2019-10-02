using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Entities
{
	public class ItemFeaturesView
	{
		public int ItemFeatureId { get; set; }

		[Required]
		public double Duration { get; set; }

		[Required]
		public int ReleaseYear { get; set; }

		[Required]
		public double FileSize { get; set; }
	}
}