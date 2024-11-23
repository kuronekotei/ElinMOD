using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;

using UnityEngine;

namespace TpMagicIndex
{
	[HarmonyPatch]
	public class MagicIndex
	{
		public static void OnStartCore() {
			var sources = Core.Instance.sources;
			foreach (SourceElement.Row ele in sources.elements.rows) {
				switch (ele.alias) {
					case "eleFire":
					case "eleCold":
					case "eleLightning":
					case "eleDarkness":
					case "eleMind":
					case "elePoison":
					case "eleNether":
					case "eleSound":
					case "eleNerve":
					case "eleHoly":
					case "eleChaos":
					case "eleMagic":
					case "eleEther":
					case "eleAcid":
					case "eleCut":
						DomainRewrite(ele);
						break;
					case "puddle_":
					case "puddle_Fire":
					case "puddle_Cold":
					case "puddle_Lightning":
					case "puddle_Darkness":
					case "puddle_Mind":
					case "puddle_Poison":
					case "puddle_Nether":
					case "puddle_Sound":
					case "puddle_Nerve":
					case "puddle_Holy":
					case "puddle_Chaos":
					case "puddle_Magic":
					case "puddle_Ether":
					case "puddle_Acid":
					case "puddle_Cut":
						SetChance(ele, 100);
						AddBook(ele);
						break;
					case "SpWish":
						SetChance(ele, 50);
						AddBook(ele);
						break;
					case "SpTransmuteBroom":
						SetChance(ele, 50);
						AddBook(ele);
						break;
					case "SpIdentifyG":
					case "SpUncurseG":
					case "SpEnchantWeapon":
					case "SpEnchantWeaponGreat":
					case "SpEnchantArmor":
					case "SpEnchantArmorGreat":
					case "SpLighten":
					case "SpFaith":
					case "SpChangeMaterialLesser":
					case "SpChangeMaterial":
					case "SpChangeMaterialG":
					case "SpTransmutePutit":
					case "SpSummonFire":
					case "SpSummonTentacle":
					case "SpExterminate":
					case "SpWardMonster":
					case "SpDrawMonster":
					case "SpDrawMetal":
					case "SpCureMutation":
					case "SpSummonMonster":
					case "SpReconstruction":
					case "SpSummonPawn":
					case "SpDrawBacker":
						AddBook(ele);
						break;
				}
			}
		}
		public static void DomainRewrite(SourceElement.Row ele) {
			string[] domainSpell = { "arrow", "hand", "bolt", "ball", "miasma", "funnel", "weapon", "breathe", "puddle" };
			ele.tag.AddToArray("rewite");
			foreach (string word in domainSpell) {
				if (!ele.tag.Contains(word)) {
					ele.tag = ele.tag.AddToArray(word);
				}
			}
		}
		public static void SetChance(SourceElement.Row ele, int chance) {
			ele.chance = chance;
		}
		public static void AddBook(SourceElement.Row ele) {
			ele.thing += "xB";
		}

		[HarmonyPrefix, HarmonyPatch(typeof(InvOwnerChangeMaterial), nameof(InvOwnerChangeMaterial.CreateDefaultContainer))]
		public static bool CreateDefaultContainer(InvOwnerChangeMaterial __instance, ref Thing __result) {
			if (__instance.mat==null ) {
				if (__instance.idEffect == EffectId.ChangeMaterialGreater || __instance.idEffect == EffectId.ChangeMaterial || __instance.idEffect == EffectId.ChangeMaterialLesser) {
					__result = ThingGen.CreateScroll(__instance.idEffect == EffectId.ChangeMaterialGreater ? 8286 : (__instance.idEffect == EffectId.ChangeMaterialLesser ? 8284 : 8285));
					return false;
				}
			}
			return true;
		}
		[HarmonyPrefix, HarmonyPatch(typeof(InvOwnerChangeMaterial), nameof(InvOwnerChangeMaterial._OnProcess))]
		public static bool _OnProcess(InvOwnerChangeMaterial __instance, Thing t) {
			if (__instance.mat == null) {
				if (__instance.idEffect == EffectId.ChangeMaterialGreater || __instance.idEffect == EffectId.ChangeMaterial || __instance.idEffect == EffectId.ChangeMaterialLesser) {
					ActEffect.Proc(__instance.idEffect, 100, __instance.state, (Card)__instance.cc, (Card)t);
					return false;
				}
			}
			return true;
		}
	}
}
