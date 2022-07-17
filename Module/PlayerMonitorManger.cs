using ModderDLL.ToolObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModderDLL.Module
{
    public class PlayerMonitorManger : MonitorManager<Player>
    {
        public override MonitorToken<Player> CreatMonitor(Mod mod, Player target, out MonitorInfo<Player> info)
        {
            MonitorToken<Player> token = PlayerMonitorToken.Creat(mod, target);
            info = PlayerMonitorInfo.Creat(token);
            Monitor.Add(token, info);
            return token;
        }
        public class PlayerMonitorToken : MonitorToken<Player>
        {
            internal PlayerMonitorToken(Mod mod, Player monitorobj) : base(mod, monitorobj)
            {
            }
        }
        public class PlayerMonitorInfo : MonitorInfo<Player>
        {
            internal PlayerMonitorInfo(Mod mod, MonitorToken<Player> token) : base(mod, token)
            {
            }
        }
    }
}
