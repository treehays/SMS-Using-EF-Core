
using SMS.model;

namespace SMS.interfaces;

public interface IProductManager
{
    void CreateProduct(Product product);
    Product GetProduct(string barCode);
    void UpdateProduct(Product product, string barCode, string productName, decimal price);
    void RestockProduct(Product product, string barCode, int quantity);
    void DeleteProduct(string barCode);
    IList<Product> SortedProductByQuantity(int quantity);
    IList<Product> ViewAllProduct();
    IList<Product> SortAllProductByName();
}