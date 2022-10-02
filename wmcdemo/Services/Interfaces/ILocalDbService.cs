using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace wmcdemo.Services.Interfaces
{
    public interface ILocalDbService
    {
        Task<bool> WriteKeyValue(string key, string value);
        Task<string> ReadKeyValue(string key);
        Task<bool> DeleteKeyValue(string key);
    }
}
