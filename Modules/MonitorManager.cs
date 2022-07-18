using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModderDLL.Modules
{
    public abstract class MonitorManager<T>
    {
        internal Dictionary<MonitorToken<T>, MonitorInfo<T>> Monitor = new();
        internal Dictionary<T, List<MonitorToken<T>>> TMonitor = new();
        internal List<MonitorInfo<T>> GetInfos(T target)
        {
            if (TMonitor.TryGetValue(target, out List<MonitorToken<T>> tokens))
            {
                List<MonitorInfo<T>> infos = new();
                foreach (MonitorToken<T> token in tokens)
                {
                    infos.Add(Monitor[token]);
                }
                return infos;
            }
            throw new KeyNotFoundException();
        }
        internal bool TryGetInfos(T target, out List<MonitorInfo<T>> infos)
        {
            if (TMonitor.TryGetValue(target, out List<MonitorToken<T>> tokens))
            {
                infos = new();
                foreach (MonitorToken<T> token in tokens)
                {
                    infos.Add(Monitor[token]);
                }
                return true;
            }
            infos = null;
            return false;
        }
        public bool Cancel(MonitorToken<T> token)
        {
            if (Monitor.ContainsKey(token))
            {
                T target = token.MonitorTarget;
                TMonitor[target].Remove(token);
                Monitor.Remove(token);
                return true;
            }
            return false;
        }
        public virtual MonitorToken<T> CreatMonitor(T target!!, Func<T, bool> cancel!!)
        {
            MonitorToken<T> token = new(target);
            MonitorInfo<T> info = new(token, cancel);
            Monitor.Add(token, info);
            if (TMonitor.TryGetValue(target, out List<MonitorToken<T>> tokens))
            {
                tokens.Add(token);
            }
            else
            {
                TMonitor.Add(target, new List<MonitorToken<T>>() { token });
            }
            return token;
        }
        public virtual void AddMonitor(MonitorInfo<T> info)
        {
            if (info.token is null)
            {
                throw new ArgumentException($"This MonitorInfo<{typeof(T).Name}>'s token is null");
            }
            if (info.token.MonitorTarget is null)
            {
                throw new ArgumentException($"This MonitorInfo<{typeof(T).Name}>'s MonitorTarget is null");
            }
            if (info.Cancel is null)
            {
                throw new ArgumentException($"This MonitorInfo<{typeof(T).Name}> doesn't set a termination condition");
            }
            Monitor.Add(info.token, info);
            if (TMonitor.TryGetValue(info.token.MonitorTarget, out List<MonitorToken<T>> tokens))
            {
                tokens.Add(info.token);
            }
            else
            {
                TMonitor.Add(info.token.MonitorTarget, new List<MonitorToken<T>>() { info.token });
            }
        }
    }
}