package com.oland.contactlist;

import android.app.Activity;
import android.content.ContentResolver;
import android.database.Cursor;
import android.provider.ContactsContract;

import java.util.HashMap;
import java.util.Map;

public class ContactList {
    static Map<Long, ContactData> contactData = new HashMap<Long, ContactData>();
    static final int NUMBER_OF_DATA = 4;

    public static void pullContacts(Activity activity, IContactContainer container) {
        String[] projection = getProjection();

        String selection = getSelection();

        ContentResolver cr = activity.getContentResolver();
        Cursor cur = cr.query(ContactsContract.Data.CONTENT_URI,
                projection,
                selection,
                null,
                null);


        while (cur != null && cur.moveToNext()) {
            long id = cur.getLong(0);
            String name = cur.getString(1);
            String mime = cur.getString(2);
            String data = cur.getString(3);

            CheckId(id, name);

            DTO dto = getDTO(mime,data);


            setContact(id, dto);
        }
        pushContactInContainer(container);
    }

    private static String[] getProjection() {
        return new String[]{ContactsContract.Data.CONTACT_ID,
                ContactsContract.Data.DISPLAY_NAME,
                ContactsContract.Data.MIMETYPE,
                ContactsContract.Data.DATA1,
                ContactsContract.Data.DATA2,
                ContactsContract.Data.DATA3};
    }

    private static String getSelection() {
        return ContactsContract.Data.MIMETYPE +
                " IN ('" +
                ContactsContract.CommonDataKinds.Phone.CONTENT_ITEM_TYPE +
                "', '" +
                ContactsContract.CommonDataKinds.Event.CONTENT_ITEM_TYPE +
                "', '" +
                ContactsContract.CommonDataKinds.Email.CONTENT_ITEM_TYPE + "')";

    }

    private static void CheckId(long id, String name) {
        if (contactData.containsKey(id)) return;
        ContactData data = new ContactData(name);
        contactData.put(id, data);
    }

    private static DTO getDTO(String mime,String data) {
        switch (mime) {
            case ContactsContract.CommonDataKinds.Phone.CONTENT_ITEM_TYPE:
                return new NumberDTO(data);
            case ContactsContract.CommonDataKinds.Event.CONTENT_ITEM_TYPE:
                return new EventDTO(data);
            case ContactsContract.CommonDataKinds.Email.CONTENT_ITEM_TYPE:
                return new EmailDTO(data);
            default:
                return new NullObjectDTO();
        }
    }

    private static void setContact(long id, DTO dto) {
        try {
            trySetContact(id, dto);
        } catch (Exception exception) {

        }
    }

    private static void trySetContact(long id, DTO dto) {
        ContactData contact = contactData.get(id);
        dto.saveData(contact);
        contactData.put(id, contact);
    }

    private static void pushContactInContainer(IContactContainer container) {
        for (Map.Entry<Long, ContactData> entry : contactData.entrySet()) {
            entry.getValue().pushContact(container);
        }
    }
}

