using Models;

namespace Services
{
  public interface IUserProductService
  {
    IEnumerable<SpecificPrices> GetCustomerProduct();
    IQueryable<SpecificPrices> GetCustomerProductByName(string customerName);
    // CustomerProduct CreateNewCustomerProduct(CustomerProduct newProduct);
    // void UpdateCustomerProduct(CustomerProduct updateProduct);
    // void DeleteCustomerProductById(CustomerProduct product);
  }
}