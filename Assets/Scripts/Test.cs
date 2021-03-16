using System;
using ContactListPlugin;
using ContactListPlugin.Platforms;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private Text contacts;
    private void Start()
    {
        var logcat = new AndroidJavaClass("com.oland.log.Log");
        var list = new ContactListPlugin.ContactList(new ContactListForAndroid());
        var contactList = list.PullContacts();
        
        for (int i = 0; i < contactList.Count; i++)
        {
            logcat.CallStatic("debugLog", "Name", contactList[i].Name);
            foreach (var number in contactList[i].Number)
            {
                logcat.CallStatic("debugLog", "Phone", number);
            }

            foreach (var email in contactList[i].Emails)
            {
                logcat.CallStatic("debugLog", "Email", email);
            }

            foreach (var @event in contactList[i].Events)
            {
                logcat.CallStatic("debugLog", "Event", @event);
            }
        }
    }
}