using System.Web.Http;
using AutoMapper;
using OnlineShop.BLL.Dto;
using OnlineShop.BLL.Interfaces.OrderInterfaces;
using OnlineShop.Models.Entities;
using OnlineShop.Models.Shop.UserService;

namespace OnlineShop.Controllers
{
	[Authorize]
	public class UserController : ApiController
	{
		private readonly IUserService _user;
		private readonly IMapper _mapper;
		private readonly IShoppingCart _icart;
		private readonly ShoppingCartView _cartView;

		public UserController(IUserService user, IMapper mapper, IShoppingCart icart)
		{
			this._user = user;
			this._mapper = mapper;
			this._icart = icart;
			this._cartView = new ShoppingCartView();
		}

		public UserController()
		{
		}

		[HttpPost]
		[Route("api/CartPanel/addItem")]
		public IHttpActionResult AddItem([FromBody] ItemView item, int quantity)
		{
			if (this.ModelState.IsValid)
			{
				ItemDto _item = this._mapper.Map<ItemDto>(item);
				bool result = this._user.AddItem(_item, quantity, this._icart);

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
		[Route("api/CartPanel/removeItem")]
		public IHttpActionResult RemoveItem([FromBody] ItemView item)
		{
			ItemDto _item = this._mapper.Map<ItemDto>(item);
			bool result = this._user.RemoveItem(_item, this._icart);
			if (result)
			{
				return this.Ok();
			}

			return this.BadRequest();
		}

		[HttpPut]
		[Route("api/CartPanel/composeOrder")]
		public IHttpActionResult ComposeCart()
		{
			IShoppingCart cart = this._user.ComposeCart(this._icart);
			if (cart == null)
			{
				return this.NotFound();
			}

			return this.Ok(cart);
		}

		[HttpPost]
		[Route("api/OrderPanel/addOrder")]
		public IHttpActionResult MakeOrder()
		{
			OrderDto _order = this._user.MakeOrder(this._icart);
			if (_order == null)
			{
				return this.NotFound();
			}

			OrderView _ordermap = this._mapper.Map<OrderView>(_order);
			return this.Ok(_ordermap);
		}
	}
}