using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;

namespace TpChatOnResidentList
{
	[HarmonyPatch]
	public class ChatOnResidentList
	{
		static Chara BaseListPeople_Chara;

		[HarmonyPrefix, HarmonyPatch(typeof(BaseListPeople), nameof(BaseListPeople.OnClick))]
		public static void BaseListPeople_OnClick(BaseListPeople __instance, Chara c, ItemGeneral i) {
			BaseListPeople_Chara = c;
			return;
		}

		[HarmonyPrefix, HarmonyPatch(typeof(UIContextMenu), nameof(UIContextMenu.AddButton), new Type[] { typeof(string), typeof(Action), typeof(bool) })]
		public static void AddButton(UIContextMenu __instance, string idLang = "", Action action = null, bool hideAfter = true) {
			if (BaseListPeople_Chara != null && idLang == "findMember") {
				__instance.AddButton("chat", (Action)(() => {
					BaseListPeople_Chara?.ShowDialog();
				}));
			}
			return;
		}
	}
}
