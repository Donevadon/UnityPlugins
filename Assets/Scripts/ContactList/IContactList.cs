using ContactList.JavaProxy;

namespace ContactList
{
    public interface IContactList
    {
        ContactContainer PullContacts();
    }
}