package com.oland.contactlist;

public abstract class DTO {
    protected String _data;
    public DTO(String data)
    {
        _data = data;
    }
    public abstract ContactData saveData(ContactData contact);
}
