using System;
using ContactList.JavaProxy;
using UnityEngine;

namespace ContactList
{
    public class ContactListForAndroid : IContactList, IDisposable
    {
        private readonly AndroidJavaObject _activity;
        private ContactContainer _container;

    
        public ContactListForAndroid()
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
    
    
        public ContactContainer PullContacts()
        {
            var container = CreateContainer();
            using (var plugin = new AndroidJavaObject("com.oland.contactlist.ContactList"))
            {
                plugin.CallStatic("pullContacts",_activity,container);
            }

            return container;
        }
    
        protected virtual ContactContainer CreateContainer()
        {
            return new ContactContainer();
        }

        public void Dispose()
        {
            _activity?.Dispose();
        }
    }
}