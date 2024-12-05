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
	[HarmonyPatch]
	public partial class MagicAppendix
	{

		[HarmonyPrefix, HarmonyPatch(typeof(Act), nameof(Act.Perform), new Type[] { })]
		public static bool Perform(Act __instance, ref bool __result) {
			if (__instance.id < 222220000) {
				return true;
			}
			__result = true;

			if (__instance.TargetType.Range == TargetRange.Self && !Act.forcePt) {
				Act.TC = Act.CC;
				Act.TP.Set(Act.CC.pos);
			}

			int pow = Act.CC.elements.GetOrCreateElement(__instance.source.id).GetPower(Act.CC) * Act.powerMod / 100;


			switch (__instance.id) {
				case 222223001:
					Demolition(__instance, pow);
					break;
				case 222223002:
					Drilling(__instance, pow);
					break;
				case 222223003:
					PullingRug(__instance, pow);
					break;
				case 222223004:
					CollectAll(__instance, pow);
					break;
				case 222223005:
					Gathering(__instance, pow);
					break;
				case 222223101:
					ReturnG(__instance, pow);
					break;
				case 222223102:
					TeleportG(__instance, pow);
					break;
				case 222223103:
					SenceObject(__instance, pow);
					break;
				case 222223201:
					ChangeWeather(__instance, pow, ChangeWeatherType.F);
					break;
				case 222223202:
					ChangeWeather(__instance, pow, ChangeWeatherType.R);
					break;
				case 222223203:
					ChangeWeather(__instance, pow, ChangeWeatherType.W);
					break;
				case 222223801:
					ForceOvulation(__instance, pow);
					break;
				case 222223802:
					ForceMilking(__instance, pow);
					break;
				case 222223803:
					ForceSqueeze(__instance, pow);
					break;
				case 222223804:
					Cultivate(__instance, pow);
					break;
				case 222223810:
					Brainwash(__instance, pow);
					break;
				case 222223999:
					EternalForceBlizzard(__instance, pow);
					break;
			}
			return false;
		}

		public static void EternalForceBlizzard(Act act, int pow) {
			Debug.Log($"EternalForceBlizzard {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}

			EMono.world.weather.SetCondition(EClass.rnd(2)==0? Weather.Condition.RainHeavy: Weather.Condition.Ether);

			List<Chara> charas = new List<Chara>(EClass._zone.map.charas);
			foreach (Chara chara in charas) {
				if (chara.hostility == Hostility.Enemy) {
					chara.Die();
				}
			}
		}

		public static void Gathering(Act act, int pow) {
			Debug.Log($"Gathering {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}
			Act.CC.PlayEffect("identify");
			Act.CC.PlaySound("identify");
			int p = (int)Math.Max((Math.Sqrt(pow) + Math.Max(Act.CC.Evalue(SKILL.LUC) / 2, 1)), 1);
			int p2 = (int)Math.Min(Math.Max(Math.Sqrt(p / 5), 2), 10);

			if (p == 0) {
				return;
			}

			string[] list = { "ore", "ore_gem", "fragment", "fiber", "chunk", "grass", "rock", "log", "glass", "brick", };
			string[] list2 = { "money2", "medal", "plat", };
			for (int i = 0; i < p2; i++) {
				int p3 = 1 + EClass.rnd(p2 / 3 + 1) + EClass.rnd(2);
				for (int j = 0; j < p3; j++) {
					int idMat = EClass.sources.materials.rows.RandomItemWeighted(a => a.chance).id;
					Thing t = ThingGen.Create(list.RandomItem(), idMat).SetNum(EClass.rnd(p));
					EClass._map.TrySmoothPick(Act.CC.Cell, t, Act.CC);
				}
			}
			Thing t2 = ThingGen.Create(list2.RandomItem()).SetNum(EClass.rnd(p2));
			if(t2.Num > 0) {
				EClass._map.TrySmoothPick(Act.CC.Cell, t2, Act.CC);
			}
		}

		public static void CollectAll(Act act, int pow) {
			Debug.Log($"CollectAll {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}
			Act.CC.PlayEffect("identify");
			Act.CC.PlaySound("identify");
			EClass._map.ForeachCell(cell => {
				List<Thing> list = new List<Thing>(cell.Things);
				list.ForEach(t => {
					if (!t.IsInstalled && !t.ignoreAutoPick) {
						EClass._map.TrySmoothPick(Act.CC.Cell, t, Act.CC);
					}
				});
			});
		}

		public static void EffectArrow(Act act, ElementRef element) {
			Effect effect = Effect.Get("spell_arrow");
			effect.sr.color = element.colorSprite;
			TrailRenderer componentInChildren = effect.GetComponentInChildren<TrailRenderer>();
			Color colorSprite;
			Color color = colorSprite = element.colorSprite;
			componentInChildren.endColor = colorSprite;
			componentInChildren.startColor = color;
			ActEffect.TryDelay((Action)(() => effect.Play(Act.CC.pos, to: Act.TP)));
		}


		public enum ChangeWeatherType
		{
			F,
			R,
			W,
		}

		public static void ChangeWeather(Act act, int pow, ChangeWeatherType t) {
			Debug.Log($"ChangeWeather {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}
			Act.CC.PlayEffect("identify");
			Act.CC.PlaySound("identify");
			var cW = EMono.world.weather.CurrentCondition;
			switch (t) {
				case ChangeWeatherType.F:
					if (cW == Weather.Condition.RainHeavy || cW == Weather.Condition.SnowHeavy) {
						EMono.world.weather.SetCondition(Weather.Condition.Rain);
					}else if(cW == Weather.Condition.Ether) {
						EMono.world.weather.SetCondition(Weather.Condition.Blossom);
					} else {
						EMono.world.weather.SetCondition(Weather.Condition.Fine);
					}
					break;
				case ChangeWeatherType.R:
					if (cW == Weather.Condition.Rain || cW == Weather.Condition.Snow) {
						EMono.world.weather.SetCondition(Weather.Condition.RainHeavy);
					} else {
						EMono.world.weather.SetCondition(Weather.Condition.Rain);
					}
					break;
				case ChangeWeatherType.W:
					if (cW == Weather.Condition.Blossom) {
						EMono.world.weather.SetCondition(Weather.Condition.Ether);
					} else {
						EMono.world.weather.SetCondition(Weather.Condition.Blossom);
					}
					break;
				default:
					break;
			}

			EClass.screen.RefreshAll();
		}
		public static void SenceObject(Act act, int pow) {
			Debug.Log($"SenceObject {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}
			Act.CC.PlayEffect("identify");
			Act.CC.PlaySound("identify");
			EClass._map.ForeachCell(cell => {
				if (cell.HasObj || cell.FirstThing != null) {
					cell.isSeen = true;
					WidgetMinimap.UpdateMap(cell.x, cell.z);
				}
			});
		}


		public static void Demolition(Act act, int pow) {
			Debug.Log($"Demolition {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}
			List<Point> listPos = EClass._map.ListPointsInCircle(Act.TP, 6.9f, mustBeWalkable: false, los: false);
			if (listPos.Count == 0) {
				listPos.Add(Act.TP.Copy());
			}

			Act.CC.Say("spell_earthquake", Act.CC, "Demolition");
			ActEffect.TryDelay(delegate {
				Act.CC.PlaySound("spell_earthquake");
			});
			if (Act.CC.IsInMutterDistance()) {
				Shaker.ShakeCam("ball");
			}

			EClass.Wait(1f, Act.CC);
			int breakPow = pow / 10 + Math.Max(Act.CC.Evalue(SKILL.STR),1);
			bool fKarma = EClass._zone.HasLaw && !EClass._zone.IsPCFaction && Act.CC.IsPC && !(EClass._zone is Zone_Vernis);

			foreach (Point pos in listPos) {
				if (pos.HasBlock && pos.matBlock.hardness <= breakPow) {
					EClass._map.MineBlock(pos, EClass._zone.IsPCFaction && Act.CC.IsPC, Act.CC);
					WidgetMinimap.UpdateMap(pos.x,pos.z);
					if (fKarma && EClass.rnd(3) == 0) {
						EClass.player.ModKarma(-1);
					}
				}
			}
		}


		public static void Drilling(Act act, int pow) {
			Debug.Log($"Drilling {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}
			List<Point> listPos = ListPointsInLine(Act.CC.pos, Act.TP, 200);
			if (listPos.Count == 0) {
				listPos.Add(Act.TP.Copy());
			}

			Act.CC.Say("spell_earthquake", Act.CC, "Drilling");
			ActEffect.TryDelay(delegate {
				Act.CC.PlaySound("spell_bolt");
			});
			if (Act.CC.IsInMutterDistance()) {
				Shaker.ShakeCam("bolt");
			}

			EClass.Wait(1f, Act.CC);
			int breakPow = pow / 10 + Math.Max(Act.CC.Evalue(SKILL.STR), 1);
			bool fKarma = EClass._zone.HasLaw && !EClass._zone.IsPCFaction && Act.CC.IsPC && !(EClass._zone is Zone_Vernis);

			foreach (Point pos in listPos) {
				if (pos.HasBlock && pos.matBlock.hardness <= breakPow) {
					EClass._map.MineBlock(pos, EClass._zone.IsPCFaction && Act.CC.IsPC, Act.CC);
					WidgetMinimap.UpdateMap(pos.x, pos.z);
					if (fKarma && EClass.rnd(3) == 0) {
						EClass.player.ModKarma(-1);
					}
				}
			}
		}
		public static List<Point> ListPointsInLine(Point center, Point to, int radius) {
			List<Point> list = new List<Point>();
			Point p = new Point(center);
			list.Add(p);
			int xa = (to.x - center.x) < 0 ? -1 : 1;
			int za = (to.z - center.z) < 0 ? -1 : 1;
			while (to.x != p.x || to.z != p.z) {
				int x = to.x - p.x;
				int z = to.z - p.z;
				int xf = Math.Abs(x) * 1000 / (Math.Abs(to.x - center.x) + 1);
				int zf = Math.Abs(z) * 1000 / (Math.Abs(to.z - center.z) + 1);
				if (xf == zf) {
					list.Add(new Point(p.x + xa, p.z));
					list.Add(new Point(p.x, p.z + za));
					p = new Point(p.x + xa, p.z + za);
				} else if (xf > zf) {
					p = new Point(p.x + xa, p.z);
				} else {
					p = new Point(p.x, p.z + za);
				}
				if (center.Distance(p) >= radius) { break; }
				if (p.x < 0 || p.z < 0 || p.x > EClass._map.Size - 1 || p.z > EClass._map.Size - 1) { break; }
				list.Add(p);
			}
			if (list.Count < 2) {
				return list;
			}
			List<Point> list2 = new List<Point>(list);
			Point p2 = new Point(p);
			while (center.Distance(p2) < radius) {
				foreach (Point p3 in list) {
					p = new Point(p2.x - center.x + p3.x, p2.z - center.z + p3.z);
					if (center.Distance(p) >= radius) { break; }
					if (p.x < 0 || p.z < 0 || p.x > EClass._map.Size - 1 || p.z > EClass._map.Size - 1) { break; }

					list2.Add(p);
				}
				if (center.Distance(p) >= radius) { break; }
				if (p.x < 0 || p.z < 0 || p.x > EClass._map.Size - 1 || p.z > EClass._map.Size - 1) { break; }
				p2 = new Point(p);
			}
			list2 = list2.Distinct().ToList();
			return list2;
		}

		public static void PullingRug(Act act, int pow) {
			Debug.Log($"PullingRug {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				Act.CC.SayNothingHappans();
				return;
			}
			List<Point> listPos = EClass._map.ListPointsInCircle(Act.TP, 6.9f, mustBeWalkable: false, los: false);
			if (listPos.Count == 0) {
				listPos.Add(Act.TP.Copy());
			}

			Act.CC.Say("spell_earthquake", Act.CC, "PullingRug");
			ActEffect.TryDelay(delegate {
				Act.CC.PlaySound("spell_earthquake");
			});
			if (Act.CC.IsInMutterDistance()) {
				Shaker.ShakeCam("ball");
			}

			EClass.Wait(1f, Act.CC);
			int breakPow = pow / 10 + Math.Max(Act.CC.Evalue(SKILL.STR), 1);
			bool fKarma = EClass._zone.HasLaw && !EClass._zone.IsPCFaction && Act.CC.IsPC && !(EClass._zone is Zone_Vernis);

			foreach (Point pos in listPos) {
				if (pos.HasFloor && (pos.sourceFloor.id != FLOOR.floor_raw && pos.sourceFloor.id != FLOOR.sky) && pos.matFloor.hardness <= breakPow) {
					EClass._map.MineFloor(pos, Act.CC, EClass._zone.IsPCFaction && Act.CC.IsPC);
					WidgetMinimap.UpdateMap(pos.x, pos.z);
					if (fKarma && EClass.rnd(3) == 0) {
						EClass.player.ModKarma(-1);
					}
				}
			}
		}

		static bool? fRetAny ;
		static bool? fRetIns ;
		public static void ReturnG(Act act, int pow) {
			Debug.Log($"ReturnG {act.id} {pow} ");
			if (!Act.CC.IsPC) {
				ActEffect.Proc(EffectId.Teleport, pow, BlessedState.Normal, Act.CC, Act.TC, new ActRef());
				return;
			}
			Act.CC.PlaySound("return_cast");
			if (EClass.player.returnInfo == null) {
				if (EClass.game.spatials.ListReturnLocations().Count == 0) {
					Msg.Say("returnNowhere");
					return;
				}

				EClass.player.returnInfo = new Player.ReturnInfo() {
					turns = 0,
					askDest = true
				};
				Msg.Say("returnBegin");
				fRetAny = fRetAny ?? EClass.debug.returnAnywhere;
				fRetIns = fRetIns ?? EClass.debug.instaReturn;
				EClass.debug.returnAnywhere = true;
				EClass.debug.instaReturn = true;
				return;
			}
			EClass.player.returnInfo = (Player.ReturnInfo)null;
			Msg.Say("returnAbort");
		}

		[HarmonyPrefix, HarmonyPatch(typeof(BaseGameScreen), nameof(BaseGameScreen.OnEndPlayerTurn))]
		public static void OnEndPlayerTurn(BaseGameScreen __instance) {
			EClass.debug.returnAnywhere = fRetAny ?? EClass.debug.returnAnywhere;
			EClass.debug.instaReturn = fRetIns ?? EClass.debug.instaReturn;
			fRetAny = null;
			fRetIns = null;
		}

		[HarmonyPrefix, HarmonyPatch(typeof(Player.Flags), nameof(Player.Flags.OnEnterZone))]
		public static void OnEnterZone(Player.Flags __instance) {
			EClass.debug.returnAnywhere = fRetAny ?? EClass.debug.returnAnywhere;
			EClass.debug.instaReturn = fRetIns ?? EClass.debug.instaReturn;
			fRetAny = null;
			fRetIns = null;
		}

		public static void TeleportG(Act act, int pow) {
			Debug.Log($"TeleportG {act.id} {pow} ");

			if (!Act.CC.IsPC) {
				ActEffect.Proc(EffectId.Teleport, pow, BlessedState.Normal, Act.CC, Act.CC, new ActRef());
				return;
			}

			if (Act.CC.pos.Equals(Act.TP)) {
				ActEffect.Proc(EffectId.Teleport, pow, BlessedState.Normal, Act.CC, Act.CC, new ActRef());
				return;
			}

			if (Act.TP.HasChara) {
				var list = Act.TP.ListCharas();
				foreach (var item in list) {
					ActEffect.Proc(EffectId.Teleport, pow, BlessedState.Normal, Act.CC, item, new ActRef());
				}
				return;
			}
			if (Act.TP.IsBlocked) {
				return;
			}

			Act.CC.Teleport(Act.TP);
		}
	}
}
