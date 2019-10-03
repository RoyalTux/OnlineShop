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
		private ShoppingCartView _cartView;

		public UserController(IUserService user, IMapper mapper, IShoppingCart icart)
		{
			_user = user;
			_mapper = mapper;
			this._icart = icart;
			_cartView = new ShoppingCartView();
		}

		public UserController()
		{
		}

		[HttpPost]
		[Route("api/CartPanel/addItem")]
		public IHttpActionResult AddItem([FromBody] ItemView item, int quantity)
		{
			if (ModelState.IsValid)
			{
				var _item = _mapper.Map<ItemDto>(item);
				var result = _user.AddItem(_item, quantity, _icart);

				if (result)
					return Ok();
			}
			else
			{
				return BadRequest(ModelState);
			}

			return BadRequest();
		}

		[HttpDelete]
		[Route("api/CartPanel/removeItem")]
		public IHttpActionResult RemoveItem([FromBody] ItemView item)
		{
			var _item = _mapper.Map<ItemDto>(item);
			var result = _user.RemoveItem(_item, _icart);
			if (result)
				return Ok();
			return BadRequest();
		}

		[HttpPut]
		[Route("api/CartPanel/composeOrder")]
		public IHttpActionResult ComposeCart()
		{
			var cart = _user.ComposeCart(_icart);
			if (cart == null)
				return NotFound();

			return Ok(cart);
		}

		[HttpPost]
		[Route("api/OrderPanel/addOrder")]
		public IHttpActionResult MakeOrder()
		{
			var _order = _user.MakeOrder(_icart);
			if (_order == null)
				return NotFound();

			var _ordermap = _mapper.Map<OrderView>(_order);
			return Ok(_ordermap);
		}
	}
}