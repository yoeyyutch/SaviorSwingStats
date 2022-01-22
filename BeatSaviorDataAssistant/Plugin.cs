using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace BeatSaviorDataAssistant
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		internal static string PluginName => "MyBS";
		internal static Plugin Instance { get; private set; }
		public static IPA.Logging.Logger log;

		[Init]
		public void Init(IPA.Logging.Logger logger, Config conf)
		{
			log = logger;
			Instance = this;
			Configuration.Init(conf);
			MyHarmony.LoadHarmonyPatches();
			log.Info("Init");
		}

		[OnStart]
		public void OnApplicationStart()
		{
			log.Debug("OnApplicationStart");
			new GameObject("BeatSaviorDataAssistantController").AddComponent<BeatSaviorDataAssistantController>();

		}

		[OnExit]
		public void OnApplicationQuit()
		{
			log.Debug("OnApplicationQuit");

		}
	}
}
