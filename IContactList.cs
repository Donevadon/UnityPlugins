using ContactListPlugin.JavaProxy;

namespace ContactListPlugin
{
    public interface IContactList
    {
        ContactContainer PullContacts();
    }
}