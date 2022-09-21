using Entities;
using Models;
using Repositories;

namespace Services
{
  class UserProductService : IUserProductService
  {
    public ICustomerProductRepository _customerProductRepository { get; }

    public UserProductService(ICustomerProductRepository customerProductRepository)
    {
      _customerProductRepository = customerProductRepository;
    }

    public CustomerProduct CreateNewCustomerProduct(CustomerProduct newProduct)
    {
      return _customerProductRepository.Create(newProduct);
    }

    // public void DeleteCustomerProductById(CustomerProduct product)
    // {
    //   throw new NotImplementedException();
    // }

    public IEnumerable<SpecificPrices> GetCustomerProduct()
    {
      var specificPrices = _customerProductRepository.FindAll()
        .GroupBy(x => x.customer)
        .Select(x => new SpecificPrices { customer = x.Key, products = x.Select(y => new Product { ProductId = y.ProductId, ean = y.product.ean, price = y.price }).ToList()});
      return specificPrices;
    }

    // public IQueryable<CustomerProduct> GetCustomerProductByName(string customerName)
    // {
    //   throw new NotImplementedException();
    // }

    // public void UpdateCustomerProduct(CustomerProduct updateProduct)
    // {
    //   throw new NotImplementedException();
    // }
  }
}