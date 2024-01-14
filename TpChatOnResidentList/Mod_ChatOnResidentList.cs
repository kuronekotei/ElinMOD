using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpChatOnResidentList
{
	[BepInPlugin("net.kuronekotei.chat_on_resident_list", "ChatOnResidentList", "1.0.0.0")]
	public class Mod_ChatOnResidentList : BaseUnityPlugin
	{
		private void Awake() {
			new Harmony("ChatOnResidentList").PatchAll();
		}
	}
}
