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
			if (this.ModelState.IsValid)
			{
				ItemDto item = this._mapper.Map<ItemDto>(itemView);
				bool result = this._adminService.AddItem(item);

				if (result)
				{
					return this.Ok();
				}
			}
			else
			{
				return this.BadRequest(this.ModelState);
			}

			return this.BadRequest();
		}

		[HttpPut]
		[Route("api/adminPanel/items/edit")]
		[Authorize(Roles = "manager")]
		public IHttpActionResult UpdateItem([FromBody]ItemView item)
		{
			if (this.ModelState.IsValid)
			{
				ItemDto _item = this._mapper.Map<ItemDto>(item);
				bool result = this._adminService.UpdateItem(_item);

				if (result)
				{
					return this.Ok();
				}
			}
			else
			{
				return this.BadRequest(this.ModelState);
			}

			return this.BadRequest();
		}

		[HttpDelete]
		[Route("api/adminPanel/items/delete/{id}")]
		public IHttpActionResult DeleteItem(int id)
		{
			bool result = this._adminService.RemoveItem(id);

			if (result)
			{
				return this.Ok();
			}

			return this.BadRequest();
		}

		[HttpGet]
		[Route("api/adminPanel/items/get/{id}")]
		public IHttpActionResult GetItem(int id)
		{
			ItemDto item = this._adminService.GetItem(id);

			if (item == null)
			{
				return this.NotFound();
			}

			ItemView _item = this._mapper.Map<ItemView>(item);
			return this.Ok(_item);
		}
	}
}