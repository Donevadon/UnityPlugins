using System.Collections.Generic;
using UnityEngine;

namespace ContactListPlugin.JavaProxy
{
    public class ContactContainer :AndroidJavaProxy, IContactContainer
    {
        private readonly List<Contact> _contacts;
        
        public int Count => _contacts.Count;

        public Contact this[int id] => _contacts[id];

        public ContactContainer() : base("com.oland.contactlist.IContactContainer")
        {
            _contacts = new List<Contact>();
        }
        
        public ContactContainer(AndroidJavaClass javaInterface) : base(javaInterface)
        {
        }
        
        
        public int createNewContact(string name)
        {
            var contact = new Contact(name);
            _contacts.Add(contact);
            return _contacts.IndexOf(contact);
        }

        
        public void setNumber(int index, string number)
        {
            _contacts[index].Number.Add(number);
        }

        
        public void setEmail(int index, string email)
        {
            _contacts[index].Emails.Add(email);
        }

        
        public void setEvent(int index, string _event)
        {
            _contacts[index].Events.Add(_event);
        }
    }
}