// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
namespace Models
{
    public class Product
    {
        public string ean { get; set; }
        public string price { get; set; }
    }

    public class ProductRoot
    {
        public List<Product> products { get; set; }
        public List<SpecificPrice> specificPrices { get; set; }
    }

    public class SpecificPrice
    {
        public string customer { get; set; }
        public List<Product> products { get; set; }
    }
}

