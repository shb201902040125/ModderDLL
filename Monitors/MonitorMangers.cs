using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;

namespace ModderDLL.Monitors
{
    public static class MonitorMangers
    {
        internal static void Load()
        {
            TileMonitor = new();
        }
        internal static void Unload()
        {
            TileMonitor = null;
        }
        public static TileMonitorManager TileMonitor;
        internal class MonitorSystem : ModSystem
        {
            public override void PostUpdateEverything()
            {
                foreach (var info in TileMonitor.GetAllInfos())
                {
                    info.RunDelegates(TileMonitorManager.TileMonitorInfo.DelegateEnum.Update);
                }
            }
        }
        internal class MonitorGlobalTile:GlobalTile
        {
            public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
            {
                foreach(var info in TileMonitor.GetInfos(Main.tile[i,j]))
                {
                    info.RunDelegates(TileMonitorManager.TileMonitorInfo.DelegateEnum.Kill);
                }
            }
            public override void RandomUpdate(int i, int j, int type)
            {
                foreach (var info in TileMonitor.GetInfos(Main.tile[i, j]))
                {
                    info.RunDelegates(TileMonitorManager.TileMonitorInfo.DelegateEnum.RandomUpdate);
                }
            }
        }
    }
}
