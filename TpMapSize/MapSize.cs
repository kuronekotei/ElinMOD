using ReflexCLI.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMapSize
{
	[ConsoleCommandClassCustomizer("")]
	public class MapSize : EScriptable
	{
		[ConsoleCommand]
		public static string _SetMapSize(int size = 100) {
			if (size < 10 || size > 250) {
				return $"_SetMapSize : size is 10～250";
			}

			EClass.pc.currentZone.map.Resize(size);
			return $"_SetMapSize = {EClass.pc.currentZone.map.Size}";
		}

		[ConsoleCommand]
		public static string _GetMapSize() {
			return $"_GetMapSize = {EClass.pc.currentZone.map.Size}";
		}

		[ConsoleCommand]
		public static string _SetMapBouns(int x, int z, int maxX, int maxZ) {
			var map = EClass.pc.currentZone.map;
			var bounds = EClass.pc.currentZone.bounds;
			if (x < 1 || z < 1 || x > maxX || z > maxZ) {
				return $"_SetMapBouns : x,z is 0～[maxX({maxX}),maxZ({maxZ})]";
			}
			if (maxX > map.Size - 2 || maxZ > map.Size - 2) {
				return $"_SetMapBouns : maxX,maxZ is < [MapSize-2 ({map.Size-2})]";
			}

			bounds.SetBounds(x, z, maxX, maxZ);

			EClass._map.RefreshAllTiles();
			ScreenEffect.Play("Firework"); 
			return $"_SetMapBouns = {bounds.x} {bounds.z} {bounds.maxX} {bounds.maxZ}";
		}

		[ConsoleCommand]
		public static string _GetMapBouns() {
			var bounds = EClass.pc.currentZone.bounds;
			return $"_GetMapBouns = {bounds.x} {bounds.z} {bounds.maxX} {bounds.maxZ}";
		}
	}
}