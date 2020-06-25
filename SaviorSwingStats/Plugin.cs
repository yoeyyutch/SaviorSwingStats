
using System.Collections.Generic;
using IPA;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using IPAPluginManager = IPA.Loader.PluginManager;
using BS_Utils.Utilities;
using UnityEngine;
using Object = UnityEngine.Object;
using IPA.Utilities;
using System.IO;
using System;

namespace SaviorSwingStats
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {

        internal static string PluginName => "SaviorSwingStats";
        readonly string directory = Path.Combine(UnityGame.UserDataPath, Plugin.PluginName);

        private StatKeeper statKeeper;
        //private GameObject plotter;

        [Init]
        public void Init(IPALogger logger) { Logger.log = logger; }

        [OnStart]
        public void OnApplicationStart()
        {
            Logger.log.Info($"{PluginName} has started.");
            Directory.CreateDirectory(directory);
		
	
			AddEvents();
		}

        [OnExit]
        public void OnApplicationExit()
        {
			//Object.Destroy(plotter);
            Logger.log.Info($"{PluginName} has exited.");
            RemoveEvents();
        }

        private void AddEvents()
        {
			BSEvents.menuSceneLoaded += OnMenuSceneLoaded;
            BSEvents.gameSceneLoaded += OnGameSceneLoaded;
            BSEvents.levelCleared += OnSongExit;
            BSEvents.levelFailed += OnSongExit;
            BSEvents.levelQuit += OnSongExit;
            BSEvents.levelRestarted += OnSongExit;
            BSEvents.songPaused += OnPause;
			BSEvents.songUnpaused += OnUnpause;
        }
        private void RemoveEvents()
        {
			BSEvents.menuSceneLoaded -= OnMenuSceneLoaded;
			BSEvents.gameSceneLoaded -= OnGameSceneLoaded;
            BSEvents.levelCleared -= OnSongExit;
            BSEvents.levelFailed -= OnSongExit;
            BSEvents.levelQuit -= OnSongExit;
            BSEvents.levelRestarted -= OnSongExit;
            BSEvents.songPaused -= OnPause;
            BSEvents.songUnpaused -= OnUnpause;
        }

        public void OnPause()
        {
            Logger.log.Info("Song Paused");
			//statKeeper.CutChart.transform.localScale = Vector3.one;
			//plotter.transform.localScale = Vector3.one;
			Logger.log.Info("Pause: Show grid");
		}

        public void OnUnpause()
        {
			//statKeeper.CutChart.transform.localScale = Vector3.zero;
			//plotter.transform.localScale = Vector3.zero;
			Logger.log.Info("Unpause: hide grid");
		}

		public void OnMenuSceneLoaded()
		{

		}

        public void OnGameSceneLoaded()
        {
			//plotter = new GameObject("Grid", typeof(MonosSaviour));
			//Object.DontDestroyOnLoad(plotter);
			//plotter.SetActive(true);
			//plotter.transform.position = Vector3.zero;
			//plotter.transform.rotation = Quaternion.identity;
			//plotter.transform.localScale = Vector3.zero;
			if (statKeeper != null)
			{
				statKeeper.Clearcuts();
				Object.Destroy(statKeeper.CutChart);
				statKeeper = null;
			}
			if (statKeeper == null)
			{
				statKeeper = new StatKeeper();
			}
			else
			{
				Logger.log.Warn("E Statkeeper already exists.");
			}
			statKeeper.CutChart.transform.localScale = Vector3.one;
			//plotter.transform.localScale = Vector3.one;
			//plotter = new GameObject("Grid", typeof(MonosSaviour));
			//Object.DontDestroyOnLoad(plotter);
			//plotter.SetActive(true);

			Logger.log.Info("1 GameSceneLoaded called");
            //evelData = new LevelData();
        }

        private void OnSongExit(StandardLevelScenesTransitionSetupDataSO data, LevelCompletionResults resuts)
        {
			statKeeper.CutChart.transform.localScale = Vector3.zero;
			//plotter.transform.localScale = Vector3.one;
			Logger.log.Info("3 Song ended");
            if (statKeeper != null)
            {
                List<string> songStatList = statKeeper.GetSongStatsheet();
                //string songStats = statKeeper.GetSongStats();
                string filename = string.Join("_", statKeeper.songName, statKeeper.songDifficulty, ".txt");
                string path = Path.Combine(directory, filename);
				
				SaveSongStats(path, songStatList);
                statKeeper.ClearStats();

            }

            //if (statKeeper == null)
            //    Logger.log.Info("7 Statkeeper deactivated.");
        }

        private void SaveSongStats(string path, List<string> statlist)
        {
			// header for statline 3;
			//string header = "Note ID, Note Time, Note type, Direction, Lane, Level, X, Y, Z, Good Cut, " + DateTime.Now.ToString() + Environment.NewLine;

			// header for statline 4:
			string header = "ID, Time, Type, Direction, Lane, Level, NoteX, NoteY, NoteZ, CutX, CutY, CutZ, NormalX, NormalY, NormalZ, MissDistance, TimeDeviation, Good Cut?" + DateTime.Now.ToString() + Environment.NewLine; 

			File.AppendAllText(path, header);
            File.AppendAllLines(path, statlist);
            Logger.log.Info("5 Song stats saved to file.");

        }
    }
}

//using (StreamWriter sw = File.AppendText(path))
//{
//    sw.WriteLine("****** Song completed at " + DateTime.Now);
//}


//private void SaveSongStats(string path, string stats)
//{
//    using (StreamWriter sw = File.AppendText(path))
//    {
//        sw.WriteLine("****** Song completed at " + DateTime.Now);
//        sw.WriteLine(stats);
//    }
//}

//private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//{
//    Logger.log.Info("OnSceneLoaded: " + scene.name + " (" + mode + ")");
//}

//private void OnSceneUnloaded(Scene scene)
//{
//    Logger.log.Info("OnSceneUnloaded: " + scene.name);
//}

//private void OnActiveSceneChanged(Scene previous, Scene current)
//{
//    Logger.log.Info("OnActiveSceneChanged: " + previous.name + " -> " + current.name);
//    DebugMaterials(current);
//}
