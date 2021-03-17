using System;
using ContactListPlugin.JavaProxy;
using UnityEngine;

namespace ContactListPlugin.Platforms
{
    public class ContactListForAndroid : IPullContacts,IDisposable
    {
        private readonly AndroidJavaObject _activity;

        public ContactListForAndroid()
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }

        public void PullContacts(IContactContainer container)
        {
            using (var plugin = new AndroidJavaObject("com.oland.contactlist.ContactList"))
            {
                plugin.CallStatic("pullContacts",_activity,container);
            }
        }

        public void Dispose()
        {
            _activity?.Dispose();
        }
    }
}