
using SMS.model;

namespace SMS.interfaces;

public interface IAdminManager
{
    void CreateAdmin(Admin admin);
    Admin GetAdmin(string staffId);
    Admin GetAdmin(string staffId, string email);
    IList<Admin> GetAllAdmin();
    void UpdateAdmin(Admin admin, string firstName, string lastName, string phoneNumber);
    void DeleteAdmin(string staffId);
    Admin Login(string staffId, string pin);
    bool UpdateAdminPassword(Admin admin, string pin);
}