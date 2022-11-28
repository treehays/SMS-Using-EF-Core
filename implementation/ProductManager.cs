using SMS.interfaces;
using SMS.model;

namespace SMS.implementation;

public class ProductManager : IProductManager
{
    // private readonly static String ConnString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
    private readonly ApplicationContext _context;
    public ProductManager()
    {
        _context = new ApplicationContext();
    }
    public void CreateProduct(Product product)
    {
        _context.products.Add(product);
        _context.SaveChanges();
        Console.WriteLine($"{product.ProductName} Added Successfully.");
        // new Product(barCode, productName, price, quantity);
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         var queryCreateProduction = $"Insert into product (barCode,productName,price,productQuantity) values ('{barCode}','{productName}','{price}','{quantity}')";
        //         using (var command = new MySqlCommand(queryCreateProduction, connection))
        //         {
        //             command.ExecuteNonQuery();
        //             var successMsg = $"{productName} Added Successfully.";
        //             Console.WriteLine(successMsg);
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
    }
    public void DeleteProduct(string barCode)
    {
        var product = _context.products.SingleOrDefault(x => x.BarCode == barCode);
        if (product != null)
        {
            Console.WriteLine($"{product.BarCode} {product.ProductName} Successfully deleted. ");
            _context.products.Remove(product);
        }

        // var product = GetProduct(barCode);
        // if (product != null)
        // {
        //     try
        //     {
        //         var deleteSuccessMsg = $"{product.BarCode} {product.ProductName} Successfully deleted. ";
        //         using (var connection = new MySqlConnection(ConnString))
        //         {
        //             connection.Open();
        //             using (var command = new MySqlCommand($"DELETE From product WHERE barCode = '{barCode}'", connection))
        //             {
        //                 command.ExecuteNonQuery();
        //                 Console.WriteLine(deleteSuccessMsg);
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("Product not found.");
        // }
    }
    public Product GetProduct(string barCode)
    {
        return _context.products.SingleOrDefault(x => x.BarCode == barCode);
        // Product product = null;
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         using (var command = new MySqlCommand($"select * From product WHERE barCode = '{barCode}'", connection))
        //         {
        //             var reader = command.ExecuteReader();
        //             while (reader.Read())
        //             {
        //                 product = new Product(reader["barCode"].ToString().ToUpper(), reader["productName"].ToString(), (decimal)(reader["price"]), Convert.ToInt32((reader["productQuantity"])));
        //             }
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        // return product is not null && product.BarCode.ToUpper() == barCode.ToUpper() ? product : null;
    }
    public void RestockProduct(Product product,string barCode, int quantity)
    {
        product.ProductQuantity = quantity <= 0 ? product.ProductQuantity : quantity + product.ProductQuantity;
        Console.WriteLine("Product Successful added..");
      
        // var product = GetProduct(barCode);
        // if (product != null)
        // {
        //     try
        //     {
        //         using (var connection = new MySqlConnection(ConnString))
        //         {
        //             var successMsg = $"{product.BarCode} Successfully Restocked.";
        //             connection.Open();
        //             var queryUpdateA = $"Update product SET productQuantity = ({quantity} + product.productQuantity) where barcode = '{barCode}'";
        //             using (var command = new MySqlCommand(queryUpdateA, connection))
        //             {
        //                 command.ExecuteNonQuery();
        //                 Console.WriteLine(successMsg);
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("Product not found.");
        // }
    }
    public void UpdateProduct(Product product,string barCode, string productName, decimal price)
    {
        product.ProductName = string.IsNullOrWhiteSpace(productName) ? product.ProductName : productName;
        product.Price = price <= 0 ? product.Price : price;
        Console.WriteLine($"{product.BarCode} Updated Successfully. ");
        // var product = GetProduct(barCode);
        // if (product != null)
        // {
        //     try
        //     {
        //         using (var connection = new MySqlConnection(ConnString))
        //         {
        //             var successMsg = $"{product.BarCode} Updated Successfully. ";
        //             connection.Open();
        //             var queryUpdateA = $"Update product SET productname = '{productName}', price = '{price}' where barcode = '{barCode}'";
        //             using (var command = new MySqlCommand(queryUpdateA, connection))
        //             {
        //                 command.ExecuteNonQuery();
        //                 Console.WriteLine(successMsg);
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("Product not found.");
        // }
    }
    
    public IList<Product> SortAllProductByName()
    {
        return _context.products.OrderBy(x => x.ProductName).Select(x => x).ToList();
    }

    public IList<Product> SortedProductByQuantity(int quantity)
    {
        return _context.products.Where(x => x.ProductQuantity <= quantity).Select(x => x).ToList();

        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         using (var command = new MySqlCommand($"select * From product where productQuantity < {quantity}", connection))
        //         {
        //             var reader = command.ExecuteReader();
        //             while (reader.Read())
        //             {
        //                 Console.WriteLine($"{reader["id"].ToString()}\t{reader["barCode"].ToString()}\t{reader["productName"].ToString()}\t{(decimal)(reader["price"])}\t{Convert.ToInt32((reader["productQuantity"]))}");
        //             }
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
    }
    public IList<Product> ViewAllProduct()
    {
        return _context.products.OrderBy(x => x.BarCode).Select(x => x).ToList();
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         using (var command = new MySqlCommand("select * From product", connection))
        //         {
        //             var reader = command.ExecuteReader();
        //             while (reader.Read())
        //             {
        //                 Console.WriteLine($"{reader["id"].ToString()}\t{reader["barCode"].ToString()}\t{reader["productName"].ToString()}\t{(decimal)(reader["price"])}\t{Convert.ToInt32((reader["productQuantity"]))}");
        //             }
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
    }
}