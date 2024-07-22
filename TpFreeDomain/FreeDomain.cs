using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;
using UnityEngine.UI;

namespace TpFreeDomain
{
	[HarmonyPatch]
	public class FreeDomain
	{
		[HarmonyPrefix, HarmonyPatch(typeof(Player), nameof(Player.SelectDomain))]
		public static bool Player_SelectDomain_Prefix(Player __instance, ref Layer __result, Action onKill) {

			__result = EClass.ui.AddLayer<LayerList>().SetListCheck(
				EClass.sources.elements.rows.FindAll((row) => row.categorySub == "eleAttack" && !row.tag.Contains("hidden"))
				, (ele) => $"{ele.GetName()} ({EClass.sources.elements.alias[ele.aliasParent].GetName()})"
				, (s, b) => {
					if (EClass.player.domains.Exists((domain) => s.id == domain)) {
						EClass.player.domains.Remove(s.id);
					} else {
						EClass.player.domains.Add(s.id);
					}
				}
				, (list) => {
					bool flag = EClass.player.domains.Count >= 3 + EClass.pc.Evalue(1402);
					foreach (UIList.ButtonPair item in list) {
						UIButton button = (item.component as ItemGeneral).button1;
						SourceElement.Row row = item.obj as SourceElement.Row;
						bool flag3 = EClass.player.domains.Exists((domain) => row.id == domain);

						button.SetCheck(flag3);
						button.interactable = (!flag || flag3);
						((Behaviour)(object)button.GetComponent<CanvasGroup>()).enabled = !button.interactable;
					}
				}
			).SetOnKill(() => onKill?.Invoke());
			return false;
		}


		//static bool isActive;

		//[HarmonyPrefix, HarmonyPatch(typeof(Player), nameof(Player.SelectDomain))]
		//public static bool Player_SelectDomain_Prefix(Player __instance, ref Layer __result, Action onKill) {
		//	if (!isActive) {
		//		isActive = true;
		//		__result = __instance.SelectDomain(() => {
		//			isActive = false;
		//			onKill?.Invoke();
		//		});
		//		return false;
		//	}
		//	return true;
		//}

		//[HarmonyPrefix, HarmonyPatch(typeof(Selectable), nameof(Selectable.interactable), MethodType.Setter)]
		//public static bool Selectable_interactable(Selectable __instance, bool value) {
		//	if (isActive) {
		//		bool flag = EClass.player.domains.Count >= 3 + EClass.pc.Evalue(1402);
		//		if (!flag && !value) {
		//			__instance.interactable = true;
		//			return false;
		//		}
		//	}
		//	return true;
		//}
	}
}
