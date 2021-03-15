namespace ContactList.JavaProxy
{
    public interface IContactContainer
    {
        int createNewContact(string name);
        void setNumber(int index,string number);
        void setEmail(int index,string email);
        void setEvent(int index,string _event);
    }
}