using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
  public class CustomerProductRepository : RepositoryBase<CustomerProduct>, ICustomerProductRepository
  {
    public CustomerProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public override IQueryable<CustomerProduct> FindAll()
    {
      return _repositoryContext.CustomerProducts.Include(x => x.product);
    }
  }
}