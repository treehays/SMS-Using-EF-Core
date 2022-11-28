using SMS.implementation;
using SMS.interfaces;
using SMS.model;

namespace SMS.menu;

public class AdminMenu
{
    private readonly IAdminManager _iAdminManager = new AdminManager();
    private readonly IAttendantManager _iAttendantManager = new AttendantManager();
    private readonly IProductManager _iProductManager = new ProductManager();
    private readonly ITransactionManager _iTransactionManager = new TransactionManager();
    private int _choice;

    public void RegisterAdminPage()
    {
        Console.WriteLine("\n\tHome >> Register >> Admin");
        Console.Write("\tEmail: ");
        var email = Console.ReadLine();
        var adminCheck = _iAdminManager.GetAdmin(email);
        if (adminCheck == null)
        {
            Console.Write("\tFirst name: ");
            var firstName = Console.ReadLine();
            Console.Write("\tLast name: ");
            var lastName = Console.ReadLine();
            Console.Write("\tPhone Number: ");
            var phoneNumber = Console.ReadLine();
            Console.Write("\tpin: ");
            var pin = Console.ReadLine();
            Console.Write("\tPost: ");
            var post = Console.ReadLine();
            var admin = new Admin(User.GenerateRandomId(), firstName, lastName, email, phoneNumber, pin, post);
            _iAdminManager.CreateAdmin(admin);

        }
        else
        {
            Console.WriteLine("Email already exist...");
        }
        var mainMenu = new MainMenu();
        mainMenu.LoginMenu();
    }


    public void LoginAdminMenu()
    {
        Console.WriteLine("\tWelcome.\n\tEnter your Staff ID and Password to login ");
        Console.Write("\tStaff ID: ");
        var staffId = Console.ReadLine();
        Console.Write("\tPin: ");
        var pin = Console.ReadLine();
        // staffId = "ALD841804"; 
        // pin = "1234";
        var admin = _iAdminManager.Login(staffId, pin);
        if (admin != null)
        {
            Console.WriteLine($"Welcome {admin.FirstName}, you've successfully Logged in!");
            AdminSubMenu(admin);
        }
        else
        {
            Console.WriteLine("\nWrong Staff ID or Password!.");
            var mainMenu = new MainMenu();
            mainMenu.LoginMenu();
        }
    }



    private void AdminSubMenu(Admin admin)
    {
        while (true)
        {
            // int choice;
            // Console.Clear();
            Console.WriteLine(@"

################################################################################
####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
####________________________________________________________________________####
####    Welcome to AZ Sales Management System. Enter valid option.          ####
####------------------------------------------------------------------------####
####>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>####
################################################################################");
            Console.WriteLine("\nHome >> Admin >>");
            Console.WriteLine("\tEnter 1 to Manage Attendant.\n\tEnter 2 to Manage Products.\n\tEnter 3 to Manage Inventory.  \n\tEnter 4 to View or Download sales Records.\n\tEnter 5 to Update Profile. \n\tEnter 6 to Update Password.\n\tEnter 7 to check Wallet Balance. \n\tEnter 8 to Logout.\n\tEnter 0 to Close.");
            bool chk;
            do
            {
                Console.Write("Enter Operation No: ");
                chk = int.TryParse(Console.ReadLine(), out _choice);
                Console.WriteLine(chk ? "" : "Invalid Input.");
            } while (!chk);

            switch (_choice)
            {
                case 0:
                    //close program

                    Console.WriteLine("Closing...");
                    break;
                case 1:
                    // Manage Attendant
                    ManageAttendantSubMenu();
                    AdminSubMenu(admin);

                    break;
                case 2:
                    // Manage Products 
                    ManageProductSubMenu();
                    AdminSubMenu(admin);
                    break;
                case 3:
                    // Manage Inventory
                    ManageInventorySubMenu();
                    AdminSubMenu(admin);
                    continue;
                case 4:
                    // View Sales Record
                    ViewSalesRecord();
                    AdminSubMenu(admin);
                    continue;
                case 5:
                    // Update detail
                    UpdateAdminDetails(admin);
                    continue;
                case 6:
                    // Update password
                    UpdateAdminPassword(admin);
                    continue;
                case 7:
                    // Check Wallet Balance
                    Console.WriteLine($"Booked Balance: {_iTransactionManager.CalculateTotalSales()}");
                    continue;
                case 8:
                    // logout
                    var mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                default:
                    continue;
            }

            break;
        }
    }


    private void ManageAttendantSubMenu()
    {
        while (true)
        {
            Console.WriteLine("\n...>> Admin >> Manage Attendants >>");
            // Console.WriteLine("\nAZn Sales Management System. \nEnter valid option.");
            Console.WriteLine("\tEnter 1 to Add new attendant.\n\tEnter 2 to view an attendant details.\n\tEnter 3 to View all attendants.\n\tEnter 4 to Update Attendant profile.\n\tEnter 5 to Reset Attendant password.  \n\tEnter 6 to Delete Attendant.\n\tEnter 7 to Logout.\n\tEnter 8 to go back \n\tEnter 0 to Close.");
            bool chk;
            do
            {
                Console.Write("Enter Operation No: ");
                chk = int.TryParse(Console.ReadLine(), out _choice);
                Console.WriteLine(chk ? "" : "Invalid Input.");
            } while (!chk);

            switch (_choice)
            {
                case 0:
                    //close
                    Console.WriteLine("Closed.");
                    // return;
                    break;
                case 1:
                    // Add new Attendant
                    var attendantMenu = new AttendantMenu();
                    attendantMenu.RegisterAttendantPage();
                    continue;
                case 2:
                    //view for attendant
                    ViewAnAttendant();
                    continue;
                case 3:
                    //view all attendant
                    Console.WriteLine("\nID\tSTAFF\tFIRST NAME\tLAST NAME\tEMAIL\tPHONE NO");
                    var listOfAttendants = _iAttendantManager.ViewAllAttendants();
                    foreach (var item in listOfAttendants)
                    {
                        Console.WriteLine($"{item.StaffId}\t{item.Email}\t{item.FirstName}\t{item.LastName}\t{item.PhoneNumber}");
                    }
                    continue;
                case 4:
                    //update attendant profile
                    UpdateAttendantDetails();
                    continue;
                case 5:
                    // reset attendant password
                    ResetAttendantPassword();
                    continue;
                case 6:
                    // Delete Attendants
                    DeleteAttendantMenu();
                    continue;
                case 7:
                    // logout
                    var mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                case 8:
                    // AdminSubMenu(admin);
                    break;
                default:
                    continue;
            }

            break;
        }
    }


    private void ManageProductSubMenu()
    {
        while (true)
        {
            Console.WriteLine("\nAZ Sales Management System. \nEnter valid option.");
            Console.WriteLine("...>> Admin >> Manage Product >>");
            Console.WriteLine("Enter 1 to Add a product. \nEnter 2 to Modify products detail. \nEnter 3 to View all Products. \nEnter 4 to Delete Product.\nEnter 5 to Go Back to Admin Menu\nEnter 6 to Logout.\nEnter 0 to Close.");

            bool chk;
            do
            {
                chk = int.TryParse(Console.ReadLine(), out _choice);
                Console.WriteLine(chk ? "" : "Invalid Input.");
            } while (!chk);

            switch (_choice)
            {
                case 0:
                    Console.WriteLine("Closed.");
                    // return;
                    break;
                case 1:
                    // Add Product
                    AddProduct();
                    continue;
                case 2:
                    // Modify product
                    Console.WriteLine("Modify Product Details.");
                    UpdateProductDetails();
                    continue;
                case 3:
                    // View All products
                    Console.WriteLine("\nID\tPRODUCT NAME\tBARCODE\tPRICE\tQTY\t");
                    _iProductManager.ViewAllProduct();
                    continue;
                case 4:
                    DeleteProductMenu();
                    continue;
                case 5:
                    // AdminSubMenu(admin);
                    break;
                case 6:
                    // logout
                    var mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                default:
                    continue;
            }

            break;
        }
    }

    private void ManageInventorySubMenu()
    {
        while (true)
        {
            Console.WriteLine("\nAZ Sales Management System. \nEnter valid option.");
            Console.WriteLine("...>> Admin >> Manage Inventory >>");
            Console.WriteLine("Enter 1 to Restock product. \nEnter 2 to View all products expected to be Reordered. \nEnter 3 to view Product lower than certain number.\nEnter 4 to Go Back to Admin Menu\nEnter 5 to Logout.\nEnter 0 to Close.");

            bool chk;
            do
            {
                chk = int.TryParse(Console.ReadLine(), out _choice);
                Console.WriteLine(chk ? "" : "Invalid Input.");
            } while (!chk);

            switch (_choice)
            {
                case 0:
                    Console.WriteLine("Closed.");
                    // return;
                    break;
                case 1:
                    // Restock product.
                    Console.WriteLine("Restock Product.");
                    RestockProduct();
                    continue;
                case 2:
                    // View all products expected to be Reordered. .
                    Console.WriteLine("List of products.");
                    SortedProductByQuantity();
                    continue;
                case 3:
                    // view Product lower than certain number.
                    continue;
                case 4:
                    // Go Back to Admin Menu
                    // AdminSubMenu(admin);
                    break;
                case 5:
                    // logout
                    var mainMenu = new MainMenu();
                    mainMenu.LoginMenu();
                    break;
                default:
                    continue;
            }

            break;
        }
    }
    private void ViewAnAttendant()
    {
        Console.Write("Staff id of the attendant : ");
        var staffId = Console.ReadLine();
        var attendant = _iAttendantManager.GetAttendant(staffId);
        if (attendant != null)
        {
            Console.WriteLine($"Staff ID: {attendant.StaffId}");
            Console.WriteLine($"Name: {attendant.FirstName} {attendant.LastName}");
            Console.WriteLine($"Email: {attendant.Email}");
            Console.WriteLine($"Phone Number: {attendant.PhoneNumber}");
            Console.WriteLine($"Post: {attendant.Post}");
        }
        else
        {
            Console.WriteLine("Attendant not found.");
            ManageAttendantSubMenu();
        }
    }

    private void ResetAttendantPassword()
    {

        Console.WriteLine("Reset Attendant password.");
        Console.Write("Staff id of the attendant : ");
        var staffId = Console.ReadLine();
        var attendant = _iAttendantManager.GetAttendant(staffId);
        if (attendant != null)
        {
            Console.Write("Enter new Password: ");
            var pin = Console.ReadLine();
            _iAttendantManager.AdminUpdateAttendantPassword(staffId, pin);
        }
        else
        {
            Console.WriteLine("Attendant not found.");
            // ManageAttendantSubMenu(admin);
        }
    }

    private void UpdateAttendantDetails()
    {
        Console.WriteLine("\nWelcome.");
        Console.Write("Staff id of the attendant to be updated: ");
        var staffId = Console.ReadLine();
        var attendant = _iAttendantManager.GetAttendant(staffId);
        if (attendant != null)
        {
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();
            Console.Write("Phone Number: ");
            var phoneNumber = Console.ReadLine();
            _iAttendantManager.UpdateAttendant(attendant, firstName, lastName, phoneNumber);
        }
        else
        {
            Console.WriteLine("Attendant not found.");
            ManageAttendantSubMenu();
        }

    }

    private void DeleteAttendantMenu()
    {
        Console.Write("Enter Staff ID of the Attendant: ");
        var staffId = Console.ReadLine();
        var attendant = _iAttendantManager.GetAttendant(staffId);
        if (attendant != null)
        {
            Console.WriteLine($"{attendant.FirstName} successfully deleted....");
            _iAttendantManager.DeleteAttendant(staffId);
        }
        else
        {
            Console.WriteLine("Attendant not found.....");
        }
    }

    private void UpdateAdminDetails(Admin admin)
    {
        // Console.Write("Enter StaffId: ");
        // var staffId = Console.ReadLine().Trim();
        Console.Write("Enter new admin first Name: ");
        var firstName = Console.ReadLine();
        Console.Write("Enter new admin last Name: ");
        var lastName = Console.ReadLine();
        Console.Write("Enter new PhoneNumber: ");
        var phoneNumber = Console.ReadLine();
        _iAdminManager.UpdateAdmin(admin, firstName, lastName, phoneNumber);
        Console.WriteLine($"{admin.StaffId} successfully updated. ");
    }

    private void UpdateAdminPassword(Admin admin)
    {
        // Console.Write("Enter StaffId: ");
        // var staffId = Console.ReadLine().Trim();
        Console.Write("Enter Old Password: ");
        var pin = Console.ReadLine();
        var adminCheck = _iAdminManager.Login(admin.StaffId, pin);
        if (adminCheck != null)
        {
            var isSame = true;
            while (isSame)
            {
                Console.WriteLine("\nEnter a matching Password.");
                Console.Write("Enter new Password: ");
                pin = Console.ReadLine();
                Console.Write("Re-Enter new Password: ");
                var rePin = Console.ReadLine();
                isSame = pin != rePin;
            }
            _iAdminManager.UpdateAdminPassword(admin, pin);
            AdminSubMenu(admin);
        }
        else
        {
            Console.WriteLine("\nIncorrect old Password!.");
            AdminSubMenu(admin);
        }
    }

    private void ViewSalesRecord()
    {
        bool check;
        Console.WriteLine("\n\tEnter 1 to view on Console.\n\tEnter 2 to generate report on SpreedSheet..\n\tEnter 3 to view report on browser.");
        do
        {
            Console.Write("Enter Operation No: ");
            check = int.TryParse(Console.ReadLine(), out _choice);
            Console.WriteLine(check ? "" : "Invalid Input.");
        } while (!check);

        switch (_choice)
        {
            case 1:
                Console.WriteLine("\nID\t TRANS. DATE \t\t\tCUSTOMER NAME\tAMOUNT\tBARCODE\tRECEIPT NO\tQTY\tTOTAL\tBALANCE");
                _iTransactionManager.GetAllTransactions();
                break;
            case 2:
            {
                Console.WriteLine("Generating the report to spreed sheet....");
                var datedNow = FileDate();
                _iTransactionManager.ViewTransactionAsExcel(datedNow);
                break;
            }
            case 3:
            {
                Console.WriteLine("Generating the report to your browser....");
                var datedNow = FileDate();
                _iTransactionManager.ViewTransactionAsHtml(datedNow);
                // AdminSubMenu(admin);
                break;
            }
        }

    }

    private void AddProduct()
    {
        Console.Write("Product Name: ");
        var productName = Console.ReadLine();
        Console.Write("Barcode(Product ID): ");
        var barCode = Console.ReadLine();
        Console.Write("Price: ");
        decimal price;
        while (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("wrong input.. Try again.");
        }
        Console.Write("Quantity: ");

        int productQuantity;
        while (!int.TryParse(Console.ReadLine(), out productQuantity))
        {
            Console.WriteLine("wrong input.. Try again.");
        }
        Product product = new Product(barCode, productName, price, productQuantity);

        _iProductManager.CreateProduct(product);
    }

    private void SortedProductByQuantity()
    {
        Console.WriteLine("\nID\tPRODUCT NAME\tBARCODE\tPRICE\tQTY\t");
        Console.Write("Enter reorder point: ");
        var quantity = int.Parse(Console.ReadLine());
        var listOfProducts = _iProductManager.SortedProductByQuantity(quantity);
        foreach (var item in listOfProducts)
        {
            Console.WriteLine($"{item.BarCode}\t{item.ProductName}\t{item.Price}\t{item.ProductQuantity}");
        }
    }

    private void RestockProduct()
    {
        Console.Write("Enter product Barcode: ");
        var barCode = Console.ReadLine().Trim();
        var product = _iProductManager.GetProduct(barCode);
        if (product != null)
        {
            Console.Write("How many to be added: ");
            int quantity;//= int.Parse(Console.ReadLine());
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("wrong input.. Try again.");
                RestockProduct();//try Continue keyword here
            }
            _iProductManager.RestockProduct(product, barCode, quantity);
        }
        else
        {
            Console.WriteLine($"{barCode} not found");
        }
    }

    private void UpdateProductDetails()
    {
        Console.Write("Enter product Barcode: ");
        var barCode = Console.ReadLine().Trim();
        var product = _iProductManager.GetProduct(barCode);
        if (product != null)
        {
            Console.Write("Enter new product Name: ");
            var productName = Console.ReadLine();
            Console.Write("Enter new price Name: ");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("wrong input.. Try again.");
                UpdateProductDetails();//try Continue keyword here
            }
            _iProductManager.UpdateProduct(product, barCode, productName, price);
            Console.WriteLine($"{barCode} successfully updated.");
        }
        else
        {
            Console.WriteLine($"{barCode} not found");
        }
    }

    private void DeleteProductMenu()
    {
        Console.Write("Enter Product BarCode: ");
        var barCode = Console.ReadLine();
        _iProductManager.DeleteProduct(barCode);

    }

    private static string FileDate()
    {
        var dateSave = string.Join("", DateTime.Now.ToShortDateString().Split('/'));
        var dateSave1 = string.Join("", DateTime.Now.ToShortTimeString().Split(':')).Remove(4);
        return dateSave + dateSave1;
    }
}