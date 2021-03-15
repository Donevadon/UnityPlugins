package com.oland.contactlist;

public class EventDTO extends DTO {


    public EventDTO(String data) {
        super(data);
    }

    @Override
    public ContactData saveData(ContactData contact) {
        contact.setEvents(_data);
        return contact;
    }

}
