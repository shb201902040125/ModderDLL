using ModderDLL.ToolObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModderDLL.Module
{
    public class TileMonitorManger:MonitorManager<Tile>
    {
        public class TileMonitorInfo : MonitorInfo<Tile>
        {
            internal TileMonitorInfo(Mod mod, MonitorToken<Tile> token) : base(mod, token)
            {
            }
        }
        public class WallMonitorInfo : MonitorInfo<Tile>
        {
            internal WallMonitorInfo(Mod mod, MonitorToken<Tile> token) : base(mod, token)
            {
            }
        }
        public class LiquidMonitorInfo : MonitorInfo<Tile>
        {
            internal LiquidMonitorInfo(Mod mod, MonitorToken<Tile> token) : base(mod, token)
            {
            }
        }
    }
}
