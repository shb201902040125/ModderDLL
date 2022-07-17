global using Terraria;
global using Terraria.ID;
global using Terraria.ModLoader;
using System.Reflection;
using System;
using System.IO;
using Terraria.ModLoader.Core;
using System.Threading;
using Terraria.ModLoader.IO;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using Steamworks;

namespace ModderDLL
{
    /// <summary>
    /// 由tml调用，不该被你使用
    /// </summary>
    public class ModderDLL : Mod
	{
		internal static ModderDLL Instance { get; private set; }
        /// <summary>
        /// 由tml调用，不该被你使用
        /// </summary>
		public ModderDLL()
        {
			Instance = this;
        }
        /// <summary>
        /// 由tml调用，不该被你使用
        /// </summary>
        public override void Load()
        {
            Hook.OnHooks.Load();
		}
        /// <summary>
        /// 由tml调用，不该被你使用
        /// </summary>
        public override void Unload()
        {
            Hook.OnHooks.Unload();
        }
        internal static bool CanUseAll => Instance is not null && SteamUser.GetSteamID().m_SteamID == 76561198827572696;

    }
}