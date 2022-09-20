namespace Controllers
{
  
  using Microsoft.AspNetCore.Mvc;
  using Models;
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
    public ProductRoot GetAllProducts()
    {
      return _productService.GetProducts();
    }

    [HttpGet("{ean}")]
    public ActionResult<Product> GetProducts(string ean) => 
            _productService.GetProductById(ean) ?? new ActionResult<Product>(NotFound());

    [HttpPost(Name = "CreateProduct")]
    public Product CreateProduct([FromBody]Product product)
    {
      return _productService.CreateNewProduct(product);
    }

    [HttpPut(Name = "UpdateProduct")]
    public Product UpdateProduct([FromBody]Product product)
    { 
      return _productService.UpdateProduct(product);
    }

    [HttpDelete("{ean}")]
    public bool DeleteProduct([FromRoute]string ean)
    {
      return _productService.DeleteProductById(ean);
    }
  }
}