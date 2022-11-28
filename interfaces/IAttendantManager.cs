
using SMS.model;

namespace SMS.interfaces;

public interface IAttendantManager
{
    void CreateAttendant(Attendant attendant);
    Attendant GetAttendant(string staffId);
    Attendant GetAttendant(string staffId, string email);
    void UpdateAttendant(Attendant attendant,string firstName, string lastName, string phoneNumber);
    void DeleteAttendant(string staffId);
    Attendant Login(string staffId, string pin);
    IList<Attendant> ViewAllAttendants();
    bool UpdateAttendantPassword(Attendant attendant, string pin);
    bool AdminUpdateAttendantPassword(string staffId, string pin);

}