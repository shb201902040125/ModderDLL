global using Terraria;
global using Terraria.ID;
global using Terraria.ModLoader;
global using ModderDLL.Support;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using System.Reflection;
global using System.IO;
global using System.Threading;
global using Steamworks;
using Terraria.ModLoader.Core;
using Terraria.ModLoader.IO;
using System.Runtime.CompilerServices;

namespace ModderDLL
{
    /// <summary>
    /// ��tml���ã����ñ���ʹ��
    /// </summary>
    public class ModderDLL : Mod
	{
		internal static ModderDLL Instance { get; private set; }
        /// <summary>
        /// ��tml���ã����ñ���ʹ��
        /// </summary>
		public ModderDLL()
        {
			Instance = this;
        }
        /// <summary>
        /// ��tml���ã����ñ���ʹ��
        /// </summary>
        public override void Load()
        {
		}
        /// <summary>
        /// ��tml���ã����ñ���ʹ��
        /// </summary>
        public override void Unload()
        {
        }
        internal static bool CanUseAll => Instance is not null && SteamUser.GetSteamID().m_SteamID == 76561198827572696;

    }
}