using HarmonyLib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class TraitTpCatsWhisker : TraitToolMusic
{
	public override void TrySetAct(ActPlan p) {
		if (p.cc.IsPC) {
			List<string> list = new List<string>() { "piano_neko", "violin_furusato", "cello_prelude", "guitar_caccini","guitar_dusk", "harpsichord_goldberg", "guitar_sad", "piano_kanon", "harp_komori" };
			string idSong = list.RandomItem();
			KnownSong song = (KnownSong)null;
			if (EClass.player.knownSongs.ContainsKey(idSong)) {
				song = EClass.player.knownSongs[idSong];
			}
			if (song == null) {
				song = new KnownSong();
				EClass.player.knownSongs[idSong] = song;
			}
			if (song.lv<2000) {
				song.lv = 2000;
			}
			EClass.player.playingSong =  new PlayingSong() {
				id = idSong,
				idTool = owner.id,
			};

		}
		base.TrySetAct(p);
		if (p.cc.IsPC) {
			var map = EClass.pc.currentZone.map;
			var listChara = map.ListCharasInCircle(EClass.pc.pos, 500, false);
			listChara.ForEach(x => x.SetAI((AIAct)new AI_Goto(EClass.pc.pos, 2)));
		}
	}
}
