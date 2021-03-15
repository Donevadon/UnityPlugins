using System.Collections.Generic;
using UnityEngine;

namespace ContactList.JavaProxy
{
    public class ContactContainer :AndroidJavaProxy, IContactContainer
    {
        private List<Contact> contacts;
        
        public int Count => contacts.Count;

        public Contact this[int id] => contacts[id];

        public ContactContainer() : base("com.oland.contactlist.IContactContainer")
        {
            contacts = new List<Contact>();
        }
        
        public ContactContainer(AndroidJavaClass javaInterface) : base(javaInterface)
        {
        }
        
        
        public int createNewContact(string name)
        {
            var contact = new Contact(name);
            contacts.Add(contact);
            return contacts.IndexOf(contact);
        }

        
        public void setNumber(int index, string number)
        {
            contacts[index].Number.Add(number);
        }

        
        public void setEmail(int index, string email)
        {
            contacts[index].Emails.Add(email);
        }

        
        public void setEvent(int index, string _event)
        {
            contacts[index].Events.Add(_event);
        }
    }
}