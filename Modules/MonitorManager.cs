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
        public List<MonitorInfo<T>> GetInfos(T target)
        {
            if (TMonitor.TryGetValue(target, out List<MonitorToken<T>> tokens))
            {
                List<MonitorInfo<T>> infos = new();
                foreach (MonitorToken<T> token in tokens)
                {
                    infos.Add(Monitor[token]);
                }
                ModifyGetInfos(infos);
                return infos;
            }
            throw new KeyNotFoundException();
        }
        public bool TryGetInfos(T target, out List<MonitorInfo<T>> infos)
        {
            if (TMonitor.TryGetValue(target, out List<MonitorToken<T>> tokens))
            {
                infos = new();
                foreach (MonitorToken<T> token in tokens)
                {
                    infos.Add(Monitor[token]);
                }
                ModifyGetInfos(infos);
                return true;
            }
            infos = null;
            return false;
        }
        internal List<MonitorInfo<T>> GetAllInfos()
        {
            List<MonitorInfo<T>> list = new();
            foreach(var info in Monitor.Values)
            {
                list.Add(info);
            }
            ModifyGetInfos(list);
            return list;
        }
        internal virtual void PreCancel(MonitorToken<T> token, MonitorInfo<T> info)
        {

        }
        internal virtual void ModifyGetInfos(List<MonitorInfo<T>> infos)
        {

        }
        public bool Cancel(MonitorToken<T> token)
        {
            if (Monitor.ContainsKey(token))
            {
                T target = token.MonitorTarget;
                MonitorInfo<T> info = Monitor[token];
                PreCancel(token, info);
                info.RunDelegates(MonitorInfo<T>.GenericDelegateEnum.Cancel);
                TMonitor[target].Remove(token);
                Monitor.Remove(token);
                return true;
            }
            return false;
        }
    }
}