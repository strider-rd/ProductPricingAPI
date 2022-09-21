namespace Controllers
{
  using Entities;
  using Microsoft.AspNetCore.Mvc;
  using Services;

  [ApiController]
  [Route("product")]
  public class ProductController : ControllerBase
  {
    private IProductService _productService { get; }

    public ProductController(IProductService productService)
    {
      _productService = productService;
    }

    [HttpGet(Name = "GetAllProducts")]
    public ActionResult<IEnumerable<Product>> GetAllProducts()
    {
      return Ok(_productService.GetProducts());
    }

    [HttpGet("{ean}")]
    public ActionResult<Product> GetProducts(string ean) => 
            _productService.GetProductById(ean).FirstOrDefault() ?? new ActionResult<Product>(NotFound());

    [HttpPost(Name = "CreateProduct")]
    public ActionResult<Product> CreateProduct([FromBody]Product product)
    {
      return Ok(_productService.CreateNewProduct(product));
    }

    [HttpPut(Name = "UpdateProduct")]
    public IActionResult UpdateProduct([FromBody]Product product)
    {
      try
      {
        _productService.UpdateProduct(product);
        return Ok();
      }
      catch (System.Exception)
      {
        return NotFound();
      }
    }

    [HttpDelete("{ean}")]
    public IActionResult DeleteProduct([FromRoute]string ean)
    {
      var existingProduct = _productService.GetProductById(ean).FirstOrDefault();
      if (existingProduct == null) return NotFound();
      _productService.DeleteProductById(existingProduct);
      return Ok(true);
    }
  }
}