using Models;
using Newtonsoft.Json;

namespace Data
{
  public class DataService : IDataService
  {
    string data = string.Empty;
    ProductRoot masterList;
    public DataService()
    {
      data = "{\r\n    \"products\": [\r\n      {\r\n        \"ean\": \"EAN1\",\r\n        \"price\": \"99.95\"\r\n      },\r\n      {\r\n        \"ean\": \"EAN2\",\r\n        \"price\": \"16.15\"\r\n      },\r\n      {\r\n        \"ean\": \"EAN3\",\r\n        \"price\": \"12\"\r\n      }\r\n    ],\r\n    \"specificPrices\": [\r\n      {\r\n        \"customer\": \"John\",\r\n        \"products\": [\r\n          {\r\n            \"ean\": \"EAN1\",\r\n            \"price\": \"95.99\"\r\n          },\r\n          {\r\n            \"ean\": \"EAN2\",\r\n            \"price\": \"16.15\"\r\n          }\r\n        ]\r\n      },\r\n      {\r\n        \"customer\": \"Mary\",\r\n        \"products\": [\r\n          {\r\n            \"ean\": \"EAN2\",\r\n            \"price\": \"16.05\"\r\n          },\r\n          {\r\n            \"ean\": \"EAN3\",\r\n            \"price\": \"9.99\"\r\n          }\r\n        ]\r\n      },\r\n      {\r\n        \"customer\": \"Lucas\",\r\n        \"products\": [\r\n          {\r\n            \"ean\": \"EAN2\",\r\n            \"price\": 14\r\n          }\r\n        ]\r\n      }\r\n    ]  \r\n  }";
      masterList = JsonConvert.DeserializeObject<ProductRoot>(data); 
    }

    public Product CreateNewProduct(Product newProduct)
    {
      masterList.products.Add(newProduct);
      return masterList.products.First(x => x.ean == newProduct.ean);
    }

    public bool DeleteProductById(string ean)
    {
      var existingData = masterList.products.FirstOrDefault(x => x.ean == ean);
      return existingData != null ? masterList.products.Remove(existingData) : false;
    }

    public Product GetProductById(string ean)
    {
      return masterList.products.FirstOrDefault(x => x.ean == ean) ?? null;
    }

    public ProductRoot GetProducts()
    {
      return masterList;
    }

    public Product UpdateExistingProduct(Product updatedProduct)
    {
      var existingData = masterList.products.First(x => x.ean == updatedProduct.ean);
      existingData.price = updatedProduct.price;
      return existingData;
    }
  }
}