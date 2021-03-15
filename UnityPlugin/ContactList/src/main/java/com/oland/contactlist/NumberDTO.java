package com.oland.contactlist;

public class NumberDTO extends DTO {

    public NumberDTO(String data) {
        super(data);
    }

    @Override
    public ContactData saveData(ContactData contact) {
        contact.setPhones(_data);
        return contact;
    }

}
