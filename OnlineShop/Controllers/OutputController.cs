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
			var item = _outputService.GetItem(id);
			if (item == null) return NotFound();
			var _item = _mapper.Map<ItemView>(item);
			return Ok(_item);

		}

		[HttpGet]
		[Route("api/output/pagination")]
		public IHttpActionResult PagingItemsList([FromUri]PaginationParams parameters)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			var page = parameters.CurrentPage;
			var pageSize = parameters.PageSize;

			var items = _outputService.GetItemsWithPagination(page, pageSize);

			if (!items.Any())
				return NotFound();

			var model = new ItemsListViewModel()
			{
				Items = _mapper.Map<IEnumerable<ItemView>>(items),
				PagingInfo = new PagingInfo()
				{
					CurrentPage = page,
					ItemsPerPage = pageSize,
					TotalItems = _outputService.GetAllItems().Count()
				}
			};

			return Ok(model);

		}

		[HttpGet]
		[Route("api/output/all_items")]
		public IHttpActionResult GetAllItems()
		{
			var items = _outputService.GetAllItems();

			if (!items.Any())
				return NotFound();

			var _items = _mapper.Map<IEnumerable<ItemView>>(items);

			return Ok(_items);
		}
	}
}