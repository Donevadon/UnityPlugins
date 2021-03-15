package com.oland.contactlist;

public class EmailDTO extends DTO {

    public EmailDTO(String data) {
        super(data);
    }

    @Override
    public ContactData saveData(ContactData contact) {
        contact.setEmails(_data);
        return contact;
    }
}
