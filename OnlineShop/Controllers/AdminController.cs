using System.Web.Http;
using AutoMapper;
using OnlineShop.BLL.Dto;
using OnlineShop.BLL.Interfaces;
using OnlineShop.Models.Entities;

namespace OnlineShop.Controllers
{
	[Authorize(Roles = "admin")]
	public class AdminController : ApiController
	{
		private readonly IAdminService _adminService;
		private readonly IMapper _mapper;

		public AdminController(IAdminService adminService, IMapper mapper)
		{
			this._adminService = adminService;
			this._mapper = mapper;
		}

		public AdminController()
		{
		}

		[HttpPost]
		[Route("api/adminPanel/items/add")]
		public IHttpActionResult AddItem([FromBody]ItemView itemView)
		{
			if (ModelState.IsValid)
			{
				var item = _mapper.Map<ItemDto>(itemView);
				var result = _adminService.AddItem(item);

				if (result)
					return Ok();
			}
			else
				return BadRequest(ModelState);

			return BadRequest();
		}

		[HttpPut]
		[Route("api/adminPanel/items/edit")]
		[Authorize(Roles = "manager")]
		public IHttpActionResult UpdateItem([FromBody]ItemView item)
		{
			if (ModelState.IsValid)
			{
				var _item = _mapper.Map<ItemDto>(item);
				var result = _adminService.UpdateItem(_item);

				if (result)
					return Ok();
			}
			else
				return BadRequest(ModelState);

			return BadRequest();
		}

		[HttpDelete]
		[Route("api/adminPanel/items/delete/{id}")]
		public IHttpActionResult DeleteItem(int id)
		{
			var result = _adminService.RemoveItem(id);

			if (result)
				return Ok();

			return BadRequest();
		}

		[HttpGet]
		[Route("api/adminPanel/items/get/{id}")]
		public IHttpActionResult GetItem(int id)
		{
			var item = _adminService.GetItem(id);

			if (item == null) return NotFound();
			var _item = _mapper.Map<ItemView>(item);
			return Ok(_item);

		}
	}
}