using System.Collections.Generic;

namespace ContactList
{
    public class Contact
    {
        public readonly string Name;
        public readonly List<string> Number;
        public readonly List<string> Emails;
        public readonly List<string> Events;

        public Contact(string name)
        {
            Name = name;
            Number = new List<string>();
            Emails = new List<string>();
            Events = new List<string>();
        }
    }
}