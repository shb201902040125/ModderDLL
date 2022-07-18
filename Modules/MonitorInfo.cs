using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModderDLL.Modules
{
    public class MonitorInfo<T>
    {
        public MonitorInfo(MonitorToken<T> token)
        {
            this.token = token;
        }
        public delegate void MonitorDelegate(T target);
        internal MonitorToken<T> token;
        internal Dictionary<Enum, MonitorDelegate> delegates = new();
        public bool SetDelegate(MonitorToken<T> token, Enum DelegateEnum, MonitorDelegate @delegate)
        {
            if (token != this.token)
            {
                return false;
            }
            if (delegates.ContainsKey(DelegateEnum))
            {
                delegates[DelegateEnum] += @delegate;
            }
            else
            {
                delegates.Add(DelegateEnum, @delegate);
            }
            return true;
        }
        internal void SetDelegate(Enum DelegateEnum, MonitorDelegate @delegate)
        {
            if (delegates.ContainsKey(DelegateEnum))
            {
                delegates[DelegateEnum] += @delegate;
            }
            else
            {
                delegates.Add(DelegateEnum, @delegate);
            }
        }
        public bool RemoveDelegate(MonitorToken<T> token, Enum DelegateEnum, MonitorDelegate @delegate)
        {
            if (token != this.token)
            {
                return false;
            }
            if (delegates.ContainsKey(DelegateEnum))
            {
                delegates[DelegateEnum] -= @delegate;
                return true;
            }
            return false;
        }
        internal bool RemoveDelegate(Enum DelegateEnum, MonitorDelegate @delegate)
        {
            if (delegates.ContainsKey(DelegateEnum))
            {
                delegates[DelegateEnum] -= @delegate;
                return true;
            }
            return false;
        }
        public bool RunDelegates(MonitorToken<T> token, Enum DelegateEnum)
        {
            if (token != this.token)
            {
                return false;
            }
            if (delegates.ContainsKey(DelegateEnum))
            {
                delegates[DelegateEnum].Invoke(token.MonitorTarget);
                return true;
            }
            return false;
        }
        internal bool RunDelegates(Enum DelegateEnum)
        {
            if (delegates.ContainsKey(DelegateEnum))
            {
                delegates[DelegateEnum].Invoke(token.MonitorTarget);
                return true;
            }
            return false;
        }
        public enum GenericDelegateEnum
        {
            Cancel
        }
    }
}
