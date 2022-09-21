using Data;
using Entities;

namespace Repositories
{
  public class ProductRepository : RepositoryBase<Product>, IProductRepository
  {
    public ProductRepository(RepositoryContext repositoryContext)
        :base(repositoryContext)
    {
      
    }
  }
}