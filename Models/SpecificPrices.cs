// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using Entities;

namespace Models
{
    public class SpecificPrices
    {
        public string customer { get; set; }
        public ICollection<Product> products { get; set; }
    }
}