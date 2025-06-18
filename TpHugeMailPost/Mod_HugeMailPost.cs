using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

namespace TpHugeMailPost
{
	[BepInPlugin("net.kuronekotei.huge_mail_post", "HugeMailPost", "1.0.0.0")]
	public class Mod_HugeMailPost : BaseUnityPlugin
	{
		public static ModConfig ModConfig;

		private void Awake() {
			new Harmony("HugeMailPost").PatchAll();
			ModConfig = new ModConfig(this.Config);
		}
		public void OnStartCore() {
			HugeMailPost.OnStartCore();
		}
	}
}
