using ModderDLL.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModderDLL.Monitors
{
    public class TileMonitorManager : MonitorManager<Tile>
    {
        public void AddMonitor(MonitorInfo<Tile> info!!)
        {
            if (info.token is null)
            {
                throw new ArgumentException($"This MonitorInfo<Tile>'s token is null");
            }
            Monitor.Add(info.token, info);
            if (TMonitor.TryGetValue(info.token.MonitorTarget, out List<MonitorToken<Tile>> tokens))
            {
                tokens.Add(info.token);
            }
            else
            {
                TMonitor.Add(info.token.MonitorTarget, new List<MonitorToken<Tile>>() { info.token });
            }
        }
        public MonitorToken<Tile> CreatMonitor(Tile target)
        {
            MonitorToken<Tile> token = new(target);
            TileMonitorInfo info = new(token, target.TileType);
            Monitor.Add(token, info);
            if (TMonitor.TryGetValue(target, out List<MonitorToken<Tile>> tokens))
            {
                tokens.Add(token);
            }
            else
            {
                TMonitor.Add(target, new List<MonitorToken<Tile>>() { token });
            }
            return token;
        }
        public class TileMonitorInfo : MonitorInfo<Tile>
        {
            public TileMonitorInfo(MonitorToken<Tile> token, int origtype) : base(token)
            {
                OrigType = origtype;
            }
            internal int OrigType;
            public enum DelegateEnum
            {
                Update,
                RandomUpdate,
                Kill
            }
        }
    }
}
