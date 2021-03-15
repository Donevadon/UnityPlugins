package com.oland.contactlist;

import java.util.ArrayList;
import java.util.List;

public class ContactData
{
    private String _name;
    private List<String> _numbers;
    private List<String> _emails;
    private List<String> _events;

    public ContactData(String name)
    {
        _name = name;
        _numbers = new ArrayList<String>();
        _emails = new ArrayList<String>();
        _events = new ArrayList<String>();
    }


    public void setEmails(String email) {
        _emails.add(email);
    }


    public void setPhones(String phone)
    {
        _numbers.add(phone);
    }


    public void setEvents(String event) {
        _events.add(event);
    }


    public void pushContact(IContactContainer container)
    {
        int index = container.createNewContact(_name);
        pushNUmbers(container,index);
        pushEmails(container,index);
        pushEvents(container,index);
    }

    private void pushNUmbers(IContactContainer container,int index)
    {
        for (String phone:_numbers) {
            container.setNumber(index,phone);
        }
    }

    private void pushEmails(IContactContainer container,int index)
    {
        for (String email:_emails) {
            container.setEmail(index,email);
        }
    }

    private void pushEvents(IContactContainer container, int index)
    {
        for (String event:_events) {
            container.setEvent(index,event);
        }
    }

}
