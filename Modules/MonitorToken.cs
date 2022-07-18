using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModderDLL.Modules
{
    public class MonitorToken<T> where T : notnull
    {
        public MonitorToken(T target)
        {
            MonitorTarget = target;
            token = MD5Support.GetMD5CodeBySystemTime();
        }
        internal string token;
        public T MonitorTarget { get; private set; }
        public override string ToString()
        {
            return $"[MonitorToken:{MonitorTarget},HashCode:{GetHashCode()}]";
        }
        public override int GetHashCode()
        {
            return token.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is MonitorToken<T> other)
            {
                return token == other.token;
            }
            return false;
        }
        public void HandedOver(MonitorToken<T> handto)
        {
            if (handto is null)
            {
                throw new NullReferenceException("Token is null.");
            }
            handto.token = token;
            token = MD5Support.GetMD5CodeBySystemTime();
        }
        public static bool operator ==(MonitorToken<T> m1, MonitorToken<T> m2)
        {
            if (m1 is null || m2 is null)
            {
                return false;
            }
            return m1.token == m2.token;
        }
        public static bool operator !=(MonitorToken<T> m1, MonitorToken<T> m2)
        {
            if (m1 is null || m2 is null)
            {
                return true;
            }
            return m1.token != m2.token;
        }
    }
}
