using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ninject.Extension.AspNetCache
{
    /// <summary>
    /// Use this class to store lock objects by a given string key
    /// </summary>
    public class KeyLockManager
    {
        private static object _syncRoot = new object();
        private Dictionary<string, object> _keyLocks = new Dictionary<string, object>();

        public object AcquireKeyLock(string key)
        {
            lock (_syncRoot)
            {
                var obj = (object)null;
                if (_keyLocks.ContainsKey(key))
                    obj = _keyLocks[key];

                if (obj == null)
                {
                    obj = new object();
                    _keyLocks.Add(key, obj);
                }

                return obj;
            }
        }
    }
}
