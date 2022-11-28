using SMS.interfaces;
using SMS.model;

namespace SMS.implementation;

public class AttendantManager : IAttendantManager
{
    // private readonly static String ConnString = "SERVER=localhost; User Id=root; Password=1234; DATABASE=sms";
    private readonly ApplicationContext _context;
    public AttendantManager()
    {
        _context = new ApplicationContext();
    }
    public void CreateAttendant(Attendant attendant)
    {
        _context.attendants.Add(attendant);
        _context.SaveChanges();
        Console.WriteLine($"Attendant Creation was Successful! \nThe Staff Identity Number is {attendant.StaffId} and pint {attendant.Pin}, \nKeep it Safe.");
        // var staffId = User.GenerateRandomId();
        // var attendant = new Attendant(staffId, firstName, lastName, email, phoneNumber, pin, post);
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         var queryCreate =
        //             $"Insert into attendant (staffId, firstname, lastname, email, phonenumber, pin, post) values ('{staffId}','{firstName}','{lastName}','{email}','{phoneNumber}','{pin}','{post}')";
        //         using (var command = new MySqlCommand(queryCreate, connection))
        //         {
        //             command.ExecuteNonQuery();
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        // Console.WriteLine($"Attendant Creation was Successful! \nThe Staff Identity Number is {attendant.StaffId} and pint {pin}, \nKeep it Safe.");
    }
    public void DeleteAttendant(string staffId)
    {
        var attendant = _context.attendants.SingleOrDefault(x => x.StaffId == staffId);
        if (attendant != null) _context.attendants.Remove(attendant);
        _context.SaveChanges();
        // var attendant = GetAttendant(staffId);
        // if (attendant != null)
        // {
        //     try
        //     {
        //         using (var connection = new MySqlConnection(ConnString))
        //         {
        //             var deleteSuccessMsg = $"{attendant.FirstName} {attendant.LastName} Successfully deleted. ";
        //             connection.Open();
        //             using (var command = new MySqlCommand($"DELETE From attendant WHERE StaffId = '{staffId}'", connection))
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
        //     Console.WriteLine("Attendant not found.");
        // }
    }
    public Attendant GetAttendant(string staffId)
    {
        return _context.attendants.SingleOrDefault(x => x.StaffId == staffId);
        // Attendant attendant = null;
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         using (var command = new MySqlCommand($"SELECT * From attendant WHERE staffId = '{staffId}'", connection))
        //         {
        //             var reader = command.ExecuteReader();
        //             while (reader.Read())
        //             {
        //                 attendant = new Attendant(reader["staffId"].ToString().ToUpper(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
        //             }
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        // return attendant is not null && attendant.StaffId.ToUpper() == staffId.ToUpper() ? attendant : null;
    }
    public Attendant GetAttendant(string staffId, string email)
    {
        return _context.attendants.SingleOrDefault(x => x.Email == email);

        // Attendant attendant = null;
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         using (var command = new MySqlCommand($"SELECT * From attendant WHERE email = '{email}'", connection))
        //         {
        //             var reader = command.ExecuteReader();
        //             while (reader.Read())
        //             {
        //                 attendant = new Attendant(reader["staffId"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
        //             }
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        // return attendant is not null && attendant.Email.ToUpper() == email.ToUpper() ? attendant : null;
    }
    public Attendant Login(string staffId, string pin)
    {
        return _context.attendants.SingleOrDefault(x => x.StaffId == staffId && x.Pin == pin);
        // Attendant attendant = null;
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         using (var command = new MySqlCommand($"SELECT * From attendant WHERE StaffId = '{staffId}'", connection))
        //         {
        //             var reader = command.ExecuteReader();
        //             while (reader.Read())
        //             {
        //                 attendant = new Attendant(reader["staffId"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["phonenumber"].ToString(), reader["Pin"].ToString(), reader["post"].ToString());
        //             }
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }
        // return attendant is not null && attendant.StaffId.ToUpper() == staffId.ToUpper() && attendant.Pin == pin ? attendant : null;
    }

    public bool UpdateAttendantPassword(Attendant attendant, string pin)
    {
        attendant.Pin = string.IsNullOrWhiteSpace(pin) ? attendant.Pin : pin;
        _context.SaveChanges();
        return pin != null;
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         var successMsg = $"password successfully updated. ";
        //         connection.Open();
        //         var queryUpdateA = $"Update attendant SET pin = '{pin}'where staffId = '{staffId}'";
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


    public bool AdminUpdateAttendantPassword(String staffId, string pin)
    {
        var attendant = GetAttendant(staffId);
        if (attendant != null)
        {
            attendant.Pin = string.IsNullOrWhiteSpace(pin) ? attendant.Pin : pin;
            _context.SaveChanges();
        }
        else
        {
            Console.WriteLine($"Attendant with Id {staffId} not found..");
        }
        return pin != null;

    }

    public void UpdateAttendant(Attendant attendant, string firstName, string lastName, string phoneNumber)
    {
        attendant.FirstName = string.IsNullOrWhiteSpace(firstName) ? attendant.FirstName : firstName;
        attendant.LastName = string.IsNullOrWhiteSpace(lastName) ? attendant.LastName : lastName;
        attendant.PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? attendant.PhoneNumber : phoneNumber;
        _context.SaveChanges();
        // var attendant = GetAttendant(staffId);
        // if (attendant != null)
        // {
        //     try
        //     {
        //         using (var connection = new MySqlConnection(ConnString))
        //         {
        //             var successMsg = $"{attendant.StaffId} Updated Successfully. ";
        //             connection.Open();
        //             var queryUpdateA = $"Update attendant SET firstname = '{firstName}', lastName = '{lastName}' where staffId = '{staffId}'";
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
        //     Console.WriteLine("Attendant not found.");
        // }
    }
    public IList<Attendant> ViewAllAttendants()
    {
        // var result = _context.attendants.ToList().SelectMany(x => ($"{x.StaffId}\t{x.FirstName}"));
        return _context.attendants.ToList();
        // try
        // {
        //     using (var connection = new MySqlConnection(ConnString))
        //     {
        //         connection.Open();
        //         using (var command = new MySqlCommand("SELECT * From attendant", connection))
        //         {
        //             var reader = command.ExecuteReader();
        //             while (reader.Read())
        //             {
        //                 Console.WriteLine($"{reader["staffID"]}\t{reader["firstName"]}\t{reader["lastName"]}\t{reader["email"]}\t{reader["phonenumber"]}\t{reader["pin"]}\t{reader["post"]}");
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