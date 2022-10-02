using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace wmcdemo.LocalDb.Realm
{
    public class KeyValueRealmObject : RealmObject
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
