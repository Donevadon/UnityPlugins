using System;
using ContactListPlugin.JavaProxy;

namespace ContactListPlugin
{
    public class ContactList : IContactList, IDisposable
    {
        private readonly IPullContacts _pullContacts;

    
        public ContactList(IPullContacts pullContacts)
        {
            _pullContacts = pullContacts;
        }
    
    
        public ContactContainer PullContacts()
        {
            var container = CreateContainer();
            _pullContacts.PullContacts(container);
            
            return container;
        }
    
        protected virtual ContactContainer CreateContainer()
        {
            return new ContactContainer();
        }

        public void Dispose()
        {
            
        }
    }
}