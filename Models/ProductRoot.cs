using Entities;

namespace Models
{
  class ProductRoot
  {
    public ICollection<Product> products { get; set; }
    public ICollection<SpecificPrices> specificPrices { get; set; }
  }
}