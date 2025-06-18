using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using HarmonyLib;

using ReflexCLI;

namespace TpLoginBonus
{
	[BepInPlugin("net.kuronekotei.tp_login_bonus", "LoginBonus", "1.0.0.0")]
	public class Mod_LoginBonus : BaseUnityPlugin
	{
		public static ModConfig ModConfig;

		private void Awake() {
			new Harmony(nameof(LoginBonus)).PatchAll();
			//ModConfig = new ModConfig(this.Config);
			CommandRegistry.assemblies.Add(this.GetType().Assembly);
		}

		public void OnStartCore() {
			LoginBonus.OnStartCore();
		}
	}
}
