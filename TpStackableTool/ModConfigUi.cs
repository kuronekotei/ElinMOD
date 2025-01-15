using System;
using System.Collections.Generic;
using HarmonyLib;
using ReflexCLI;

using UnityEngine.Events;

namespace TpStackableTool
{
	[HarmonyPatch]
	public class ModConfigUi
	{
		const string c_ConfigTitle = "Tp_StackableTool";

		[HarmonyPatch(typeof(ActPlan), "ShowContextMenu")]
		[HarmonyPrefix]
		public static void Prefix(ActPlan __instance) {

			if (!__instance.pos.Equals(EClass.pc.pos)) {
				return;
			}

			ModConfig config = Mod_StackableTool.ModConfig;
			DynamicAct act = new DynamicAct(c_ConfigTitle, ()=>{
				UIContextMenu val2 = EClass.ui.CreateContextMenu("ContextMenu");
				_AddToggleContextMenu(config.IsStack_stethoscope, "IsStack_stethoscope", val2);
				_AddToggleContextMenu(config.IsStack_lockpick, "IsStack_lockpick", val2);
				_AddToggleContextMenu(config.IsStack_blanketFire, "IsStack_blanketFire", val2);
				_AddToggleContextMenu(config.IsStack_blanketCold, "IsStack_blanketCold", val2);
				_AddToggleContextMenu(config.IsStack_whipLove, "IsStack_whipLove", val2);
				_AddToggleContextMenu(config.IsStack_whipInterest, "IsStack_whipInterest", val2);
				val2.Show();
				return false;
			}, false);
			((List<ActPlan.Item>)(object)__instance.list).Add(new ActPlan.Item {
				act = (Act)(object)act
			});
		}

		static void _AddToggleContextMenu( BepInEx.Configuration.ConfigEntry<bool> flag, string name, UIContextMenu menu ) {
			menu.AddToggle(name, flag.Value, (v) => {
				flag.Value = v;
			});
		}

		[HarmonyPatch(typeof(ActPlan.Item), "Perform")]
		[HarmonyPrefix]
		public static bool Prefix(ActPlan.Item __instance) {
			var val = __instance.act as DynamicAct;
			if (val != null && val.id == c_ConfigTitle) {
				((Act)val).Perform();
				return false;
			}
			return true;
		}
	}
}
