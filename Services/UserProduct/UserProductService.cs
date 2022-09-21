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
      var specificPrices = _customerProductRepository.FindAll().ToSpecificPrices();
      return specificPrices;
    }

    public IQueryable<SpecificPrices> GetCustomerProductByName(string customerName)
    {
      var specificPrices = _customerProductRepository.FindByCondition(x => x.customer.ToLower() == customerName.ToLower())
                                                      .ToSpecificPrices();
      return specificPrices;
    }

    // public void UpdateCustomerProduct(CustomerProduct updateProduct)
    // {
    //   throw new NotImplementedException();
    // }
  }
}