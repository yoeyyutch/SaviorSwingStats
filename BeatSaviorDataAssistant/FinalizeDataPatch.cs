using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BeatSaviorData;

namespace BeatSaviorDataAssistant
{
	[HarmonyPatch(typeof(BeatSaviorData.Plugin), "UploadData")]
	class FinalizeDataPatch
	{
		public static void PostFix(SongData ___songData)
		{

		}

	}
}
