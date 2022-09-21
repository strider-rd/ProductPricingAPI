using Data;
using Entities;

namespace Repositories
{
  public class CustomerProductRepository : RepositoryBase<CustomerProduct>, ICustomerProductRepository
  {
    public CustomerProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
  }
}