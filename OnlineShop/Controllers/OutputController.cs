using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using OnlineShop.BLL.Interfaces;
using OnlineShop.Models.Entities;
using OnlineShop.Models.Shop.OutputService;
using OnlineShop.Models.Shop.UserService;

namespace OnlineShop.Controllers
{
	public class OutputController : ApiController
	{
		private readonly IOutputService _outputService;
		private readonly IMapper _mapper;

		public OutputController(IOutputService outputService, IMapper mapper)
		{
			this._outputService = outputService;
			this._mapper = mapper;
		}

		public OutputController()
		{ }

		[HttpGet]
		[Route("api/output/items/get/{id}")]
		public IHttpActionResult GetItem(int id)
		{
			BLL.Dto.ItemDto item = this._outputService.GetItem(id);
			if (item == null)
			{
				return this.NotFound();
			}

			ItemView _item = this._mapper.Map<ItemView>(item);
			return this.Ok(_item);
		}

		[HttpGet]
		[Route("api/output/pagination")]
		public IHttpActionResult PagingItemsList([FromUri]PaginationParams parameters)
		{
			if (!this.ModelState.IsValid)
			{
				return this.BadRequest(this.ModelState);
			}

			int page = parameters.CurrentPage;
			int pageSize = parameters.PageSize;

			IEnumerable<BLL.Dto.ItemDto> items = this._outputService.GetItemsWithPagination(page, pageSize);

			if (!items.Any())
			{
				return this.NotFound();
			}

			ItemsListViewModel model = new ItemsListViewModel()
			{
				Items = this._mapper.Map<IEnumerable<ItemView>>(items),
				PagingInfo = new PagingInfo()
				{
					CurrentPage = page,
					ItemsPerPage = pageSize,
					TotalItems = this._outputService.GetAllItems().Count()
				}
			};

			return this.Ok(model);
		}

		[HttpGet]
		[Route("api/output/all_items")]
		public IHttpActionResult GetAllItems()
		{
			IEnumerable<BLL.Dto.ItemDto> items = this._outputService.GetAllItems();

			if (!items.Any())
			{
				return this.NotFound();
			}

			IEnumerable<ItemView> _items = this._mapper.Map<IEnumerable<ItemView>>(items);

			return this.Ok(_items);
		}
	}
}