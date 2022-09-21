// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using Entities;

namespace Models
{
    public class SpecificPrices
    {
        public string customer { get; set; }
        public ICollection<Product> products { get; set; }
    }

    public static class ConverCustomerProductToSpecificPrices
    {
        public static IQueryable<SpecificPrices> ToSpecificPrices(this IQueryable<CustomerProduct> customerProduct)
        {
            return customerProduct.GroupBy(x => x.customer)
                                    .Select(x => new SpecificPrices 
                                    { 
                                        customer = x.Key, 
                                        products = x.Select(y => new Product 
                                        { 
                                            ProductId = y.ProductId, 
                                            ean = y.product.ean, 
                                            price = y.price 
                                        }).ToList()
                                    });
        }
    }
}