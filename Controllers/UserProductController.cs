using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers
{
  [ApiController]
  [Route("user-product")]
  public class UserProductController : ControllerBase
  {
    public IUserProductService _userProductService { get; }
    public UserProductController(IUserProductService userProductService)
    {
      _userProductService = userProductService;
    }

    [HttpGet()]
    public ActionResult<IEnumerable<CustomerProduct>> GetAll()
    {
      return Ok(_userProductService.GetCustomerProduct());
    }
  }
}