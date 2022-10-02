using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wmcdemo.LocalDb.Realm;
using wmcdemo.Services.Interfaces;

namespace wmcdemo.Services.Implementations
{
    public class RealmDbService : ILocalDbService
    {
        const string dbName = "wmc.realm";

        public Realm RealmInstance;

        public RealmDbService()
        {
            Setup();
        }

        private void Setup()
        {
            var config = new RealmConfiguration(dbName) { };
            RealmInstance = Realm.GetInstance(config);
        }

        public async Task<bool> DeleteKeyValue(string key)
        {
            try
            {
                using (var db = RealmInstance.BeginWrite())
                {
                    var toRemove = RealmInstance.All<KeyValueRealmObject>().Where(x => x.Key == key).FirstOrDefault();
                    RealmInstance.Remove(toRemove);
                    db.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<string> ReadKeyValue(string key)
        {
            try
            {
                return RealmInstance.All<KeyValueRealmObject>().Where(x => x.Key == key).FirstOrDefault().Value;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> WriteKeyValue(string key, string value)
        {
            try
            {
                RealmInstance.Write(() =>
                {
                    RealmInstance.Add(new KeyValueRealmObject { Key = key, Value = value });
                });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
