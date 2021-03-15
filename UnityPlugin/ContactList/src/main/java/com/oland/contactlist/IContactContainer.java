package com.oland.contactlist;

public interface IContactContainer
{
    int createNewContact(String name);
    void setNumber(int index,String number);
    void setEmail(int index,String email);
    void setEvent(int index,String _event);
}
