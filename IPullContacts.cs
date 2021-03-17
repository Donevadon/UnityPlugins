using ContactListPlugin.JavaProxy;

namespace ContactListPlugin
{
    public interface IPullContacts
    {
        void PullContacts(IContactContainer container);
    }
}