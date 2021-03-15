package com.oland.contactlist;

public class NullObjectDTO extends DTO {

    public NullObjectDTO() {
        super(null);
    }

    @Override
    public ContactData saveData(ContactData contact) {
        throw null;
    }

}
