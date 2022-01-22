
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using System.Reflection;



namespace BeatSaviorDataAssistant
{
	public class MyHarmony
	{
		internal const string HARMONYID = "com.yoeyyutch.beatsaviordatassistant.";
		internal static bool harmonyPatchesLoaded = false;
		internal static readonly Harmony harmonyInstance = new HarmonyLib.Harmony(string.Concat(HARMONYID, Plugin.PluginName));

		internal static void LoadHarmonyPatches()
		{
			if (harmonyPatchesLoaded)
			{
				//Logger.Log.Info("Harmony patches already loaded. Skipping...");
				return;
			}
			try
			{
				harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
				Plugin.log.Info("Harmony patches loaded");
			}
			catch (Exception e)
			{
				Plugin.log.Error("Harmony failed to load");
				Plugin.log.Error(e.ToString());
			}
			harmonyPatchesLoaded = true;
		}
		internal static void UnloadHarmonyPatches()
		{
			if (!harmonyPatchesLoaded)
			{
				return;
			}
			try
			{
				harmonyInstance.UnpatchAll(HARMONYID);
				Plugin.log.Info("Harmony patches unloaded");
			}
			catch (Exception e)
			{
				Plugin.log.Error("Harmony failed to unload");
				Plugin.log.Error(e.ToString());
			}
			harmonyPatchesLoaded = false;
		}

	}
}

