using SMS.interfaces;
using SMS.model;

namespace SMS.implementation;

public class AdminManager : IAdminManager
{

    private readonly ApplicationContext _context;
    public AdminManager()
    {
        _context = new ApplicationContext();
    }
    public void CreateAdmin(Admin admin)
    {
        _context.admins.Add(admin);
        _context.SaveChanges();
        Console.WriteLine($"Dear {admin.FirstName}, Registration Successful! \nYour Staff Identity Number is {admin.StaffId}, \nKeep it Safe.\n");
    }
    public void DeleteAdmin(string staffId)
    {
        var admin = _context.admins.SingleOrDefault(x => x.StaffId == staffId);
        if (admin != null)
        {
            _context.admins.Remove(admin);
            Console.WriteLine($"Dear {admin.FirstName}, Successful Deleted!");
        }
    }
    public Admin GetAdmin(string staffId)
    {
        return _context.admins.SingleOrDefault(x => x.StaffId == staffId);

    }
    public IList<Admin> GetAllAdmin()
    {
        return _context.admins.ToList();

    }
    public Admin GetAdmin(string staffId, string email)
    {
        return _context.admins.SingleOrDefault(x => x.Email == email);
    }
    public Admin Login(string staffId, string pin)
    {
        return _context.admins.SingleOrDefault(x => x.StaffId == staffId && x.Pin == pin);
    }
    public bool UpdateAdminPassword(Admin admin, string pin)
    {
        admin.Pin = string.IsNullOrWhiteSpace(pin) ? admin.Pin : pin;
        _context.SaveChanges();
        return pin != null;
    }
    public void UpdateAdmin(Admin admin, string firstName, string lastName, string phoneNumber)
    {
        admin.FirstName = string.IsNullOrWhiteSpace(firstName) ? admin.FirstName : firstName;
        admin.LastName = string.IsNullOrWhiteSpace(lastName) ? admin.LastName : lastName;
        admin.PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? admin.PhoneNumber : phoneNumber;
        _context.SaveChanges();
    }
}