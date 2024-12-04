using HarmonyLib;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using UnityEngine;

namespace TpMagicAppendix
{
	public partial class MagicAppendix
	{
		public static void Brainwash(Act act, int pow) {
			Debug.Log($"Brainwash {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}

			EffectArrow(act, EClass.setting.elements[nameof(SKILL.eleMind)]);
			var cell = EClass._map.cells[Act.TP.x, Act.TP.z];
			cell.Charas.ForEach(chara => {
				if ((chara.hostility == Hostility.Enemy || chara.hostility == Hostility.Neutral)
				&& chara.CanBeTempAlly(Act.CC)
				&& Math.Max(chara.Evalue(SKILL.CHA), 1) / 10 <= Math.Max(pow / 100, 1) * Math.Max(Act.CC.Evalue(SKILL.CHA) / 20, 1)) {
					chara.PlayEffect("boost");
					chara.PlaySound("boost");
					chara.ShowEmo(Emo.love);
					chara.lastEmo = Emo.angry;
					chara.MakeMinion(Act.CC);
				}
			});
		}
		public static void ForceSqueeze(Act act, int pow) {
			Debug.Log($"ForceSqueeze {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}

			EffectArrow(act, EClass.setting.elements[nameof(SKILL.eleMind)]);
			var cell = EClass._map.cells[Act.TP.x, Act.TP.z];
			cell.Charas.ForEach(chara => {
				if (Math.Max(chara.Evalue(SKILL.CHA), 1) / 10 <= Math.Max(pow / 100, 1) * Math.Max(Act.CC.Evalue(SKILL.CHA) / 10, 1)) {
					Thing t = chara.MakeGene((EClass.rnd(5) == 0) ? (DNA.Type?)DNA.Type.Superior : null);
					chara.Talk("giveBirth");
					EClass._zone.TryAddThing(t, chara.pos);
					chara.PlayEffect("revive");
					chara.PlaySound("egg");
					chara.PlayAnime(AnimeID.Shiver);
				}
			});
		}

		public static void Cultivate(Act act, int pow) {
			Debug.Log($"ForceOvulation {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}

			EffectArrow(act, EClass.setting.elements[nameof(SKILL.eleCut)]);
			var cell = EClass._map.cells[Act.TP.x, Act.TP.z];
			cell.Charas.ForEach(chara => {
				if (Math.Max(chara.Evalue(SKILL.LER), 1) / 10 <= Math.Max(pow / 10, 1) * Math.Max(Act.CC.Evalue(SKILL.LER) / 10, 1)) {
					Thing thing = ThingGen.Create((EClass.rnd(5) == 0) ? "meat_marble" : "_meat").SetNum(1);
					thing.MakeFoodFrom(chara);
					thing.c_idMainElement = chara.c_idMainElement;
					chara.GiveBirth(thing, true);
				}
			});
		}
		public static void ForceOvulation(Act act, int pow) {
			Debug.Log($"ForceOvulation {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}

			EffectArrow(act, EClass.setting.elements[nameof(SKILL.eleMind)]);
			var cell = EClass._map.cells[Act.TP.x, Act.TP.z];
			cell.Charas.ForEach(chara => {
				if (Math.Max(chara.Evalue(SKILL.CHA), 1) / 10 <= Math.Max(pow / 10, 1) * Math.Max(Act.CC.Evalue(SKILL.CHA) / 10, 1)) {
					Thing thing = ThingGen.Create((EClass.rnd(5) == 0) ? "egg_fertilized" : "_egg").SetNum(1);
					thing.MakeFoodFrom(chara);
					thing.c_idMainElement = chara.c_idMainElement;
					chara.GiveBirth(thing, true);
				}
			});
		}

		public static void ForceMilking(Act act, int pow) {
			Debug.Log($"ForceOvulation {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}

			EffectArrow(act, EClass.setting.elements[nameof(SKILL.eleMind)]);
			var cell = EClass._map.cells[Act.TP.x, Act.TP.z];
			cell.Charas.ForEach(chara => {
				if (Math.Max(chara.Evalue(SKILL.CHA), 1) / 10 <= Math.Max(pow / 10, 1) * Math.Max(Act.CC.Evalue(SKILL.CHA) / 10, 1)) {
					chara.MakeMilk();
				}
			});
		}
	}
}
