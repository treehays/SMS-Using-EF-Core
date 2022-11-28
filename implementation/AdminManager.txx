/*

using MySql.Data.MySqlClient;
using SMS.model;
public class AdminManager : IAdminManager
{

    // ITransactionManager _iTransactionManager = new TransactionManager();
    // private static String ConnString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
    private readonly ApplicationContext _context;
    public AdminManager()
    {
        _context = new ApplicationContext();
    }
    public void CreateAdmin(Admin admin)
    {

        _context.admins.Add(admin);
        _context.SaveChanges();
        /*
         var staffId = User.GenerateRandomId();
         var admin = new Admin(staffId, firstName, lastName, email, phoneNumber, pin, post);
         try
         {
             using (var connection = new MySqlConnection(ConnString))
             {
                 connection.Open();
                 var queryCreate =
                     $"Insert into admin (staffId, firstname, lastname, email, phoneNumber, pin, post) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{post}')";

                 using (var command = new MySqlCommand(queryCreate, connection))
                 {
                     command.ExecuteNonQuery();
                 }
             }
         }
         catch (Exception ex)
         {
             Console.WriteLine(ex.Message); 
         }
         
        Console.WriteLine($"Dear {admin.FirstName}, Registration Successful! \nYour Staff Identity Number is {admin.StaffId}, \nKeep it Safe.\n");
    }
    public void DeleteAdmin(string staffId)
    {
        var admin = _context.admins.SingleOrDefault(x => x.StaffId == staffId);
        _context.admins.Remove(admin);

        // var admin = GetAdmin(staffId);
        // if (admin != null)
        // {
        //     try
        //     {
        //         var deleteSuccessMsg = $"{admin.FirstName} {admin.LastName} Successfully deleted. ";
        //         using (var connection = new MySqlConnection(ConnString))
        //         {
        //             connection.Open();
        //             using (var command = new MySqlCommand($"DELETE From admin WHERE StaffId = '{staffId}'", connection))
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
        //     Console.WriteLine("User not found.");
        // }
        
    }
    public Admin GetAdmin(string staffId)
    {
        return _context.admins.SingleOrDefault(x => x.StaffId == staffId);

        // Admin admin = null;
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         using (var command = new MySqlCommand($"select * From admin WHERE staffId = '{staffId}'", connection))
        //         {
        //             var reader = command.ExecuteReader();
        //             while (reader.Read())
        //             {
        //                 admin = new Admin(reader["staffId"].ToString().ToUpper(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
        //             }
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        // return admin is not null && admin.StaffId.ToUpper() == staffId.ToUpper() ? admin : null;
    }
    public IList<Admin> GetAllAdmin()
    {
        return _context.admins.ToList();
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         using (var command = new MySqlCommand("select * From admin", connection))
        //         {
        //             var reader = command.ExecuteReader();
        //             while (reader.Read())
        //             {
        //                 Console.WriteLine($"{reader["id"]}\t{reader["staffId"].ToString()}\t{reader["firstName"].ToString()}\t{reader["lastName"].ToString()}\t{reader["email"].ToString()}\t{reader["phonenumber"].ToString()}\t{reader["post"].ToString()}");
        //             }
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }

    }
    public Admin GetAdmin(string staffId, string email)
    {
        return _context.admins.SingleOrDefault(x => x.Email == email);
        // Admin admin = null;
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         using (var command = new MySqlCommand($"select * From attendant WHERE email = '{email}'", connection))
        //         {
        //             var reader = command.ExecuteReader();
        //             while (reader.Read())
        //             {
        //                 admin = new Admin(reader["staffId"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
        //             }
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        // return admin is not null && admin.Email.ToUpper() == email.ToUpper() ? admin : null;
    }
    public Admin Login(string staffId, string pin)
    {
        return _context.admins.SingleOrDefault(x => x.StaffId == staffId && x.Pin == pin);
        // Admin admin = null;
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         using (var command = new MySqlCommand($"select * From admin WHERE StaffId = '{staffId}'", connection))
        //         {
        //             var reader = command.ExecuteReader();
        //             while (reader.Read())
        //             {
        //                 admin = new Admin(reader["staffId"].ToString(), reader.GetString(2), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
        //             }
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        // return admin is not null && admin.StaffId.ToUpper() == staffId.ToUpper() && admin.Pin == pin ? admin : null;
    }
    public bool UpdateAdminPassword(Admin admin, string pin)
    {
        admin.Pin = string.IsNullOrWhiteSpace(pin) ? admin.Pin : pin;
        _context.SaveChanges();
        return pin != null ? true : false;
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         const string successMsg = $"password successfully updated. ";
        //         connection.Open();
        //         var queryUpdateA = $"Update admin SET pin = '{pin}'where staffId = '{staffId}'";
        //         using (var command = new MySqlCommand(queryUpdateA, connection))
        //         {
        //             command.ExecuteNonQuery();
        //             Console.WriteLine(successMsg);
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
    }
    public void UpdateAdmin(Admin admin, string firstName, string lastName, string phoneNumber)
    {
        admin.FirstName = string.IsNullOrWhiteSpace(firstName) ? admin.FirstName : firstName;
        admin.LastName = string.IsNullOrWhiteSpace(lastName) ? admin.LastName : lastName;
        admin.PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? admin.PhoneNumber : phoneNumber;
        _context.SaveChanges();
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         var successMsg = $"{staffId} Updated Successfully. ";
        //         connection.Open();
        //         var queryUpdateA = $"Update admin SET firstName = '{firstName}', lastName = '{lastName}',phoneNumber = '{phoneNumber}' where staffId = '{staffId}'";
        //         using (var command = new MySqlCommand(queryUpdateA, connection))
        //         {
        //             command.ExecuteNonQuery();
        //             Console.WriteLine(successMsg);
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
    }
}
*/