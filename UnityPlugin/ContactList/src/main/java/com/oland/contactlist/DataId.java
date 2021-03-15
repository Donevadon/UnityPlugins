package com.oland.contactlist;

public enum DataId
{
    NAME(0),PHONE(1),EMAIL(2),BIRTHDAY(3);
    private int code;
    DataId(int code) {
        this.code = code;
    }
    public int getCode()
    {
        return code;
    }
}
