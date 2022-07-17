using ModderDLL.Module;
using ModderDLL.ToolObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModderDLL.Support
{
    /// <summary>
    /// 监测管理器
    /// </summary>
    public static class MonitorSupport
    {
        internal static void Load()
        {
            PlayerMonitor = new();
            //NPCMonitor = MonitorManager<NPC>.Creat();
            //ProjectileMonitor = MonitorManager<Projectile>.Creat();
            //DustMonitor = MonitorManager<Dust>.Creat();
            //ItemMonitor = MonitorManager<Item>.Creat();
            //GoreMonitor = MonitorManager<Gore>.Creat();
            //TileMonitor = MonitorManager<Tile>.Creat();
        }
        internal static void Unload()
        {
            PlayerMonitor = null;
            NPCMonitor = null;
            ProjectileMonitor = null;
            DustMonitor = null;
            ItemMonitor = null;
            GoreMonitor = null;
            TileMonitor = null;
        }
        /// <summary>
        /// 管理对Player的追踪
        /// </summary>
        public static PlayerMonitorManger PlayerMonitor;
        /// <summary>
        /// 管理对NPC的追踪
        /// </summary>
        public static MonitorManager<NPC> NPCMonitor;
        /// <summary>
        /// 管理对Projectile的追踪
        /// </summary>
        public static MonitorManager<Projectile> ProjectileMonitor;
        /// <summary>
        /// 管理对Dust的追踪
        /// </summary>
        public static MonitorManager<Dust> DustMonitor;
        /// <summary>
        /// 管理对Item的追踪
        /// </summary>
        public static MonitorManager<Item> ItemMonitor;
        /// <summary>
        /// 管理对Gore的追踪
        /// </summary>
        public static MonitorManager<Gore> GoreMonitor;
        /// <summary>
        /// 管理对Tile的追踪
        /// </summary>
        public static MonitorManager<Tile> TileMonitor;
        /// <summary>
        /// 通用的任务类型枚举
        /// </summary>
        public enum GenericMonitorEnum
        {
            /// <summary>
            /// 注销
            /// </summary>
            Cancel
        }
        /// <summary>
        /// Tile的任务类型枚举
        /// </summary>
        public enum TileMonitorEnum
        {
            /// <summary>
            /// 在ModSystem.PostUpdate中运行,如果监测对象发生变化,则会触发注销
            /// </summary>
            Update
        }
    }
}