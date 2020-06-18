
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

        // private GameScenesManager _sceneManager;
        //public GameScenesManager GetScenesManager => _sceneManager;

        private StatKeeper statKeeper;


        [Init]
        public void Init(IPALogger logger) { Logger.log = logger; }

        [OnStart]
        public void OnApplicationStart()
        {
            //_sceneManager = Resources.FindObjectsOfTypeAll<GameScenesManager>().First();

            Directory.CreateDirectory(directory);
            GameObject gridGo = new GameObject("Grid",typeof(MonosSaviour));
            Object.DontDestroyOnLoad(gridGo);

            BSEvents.levelCleared += OnSongExit;
            BSEvents.levelFailed += OnSongExit;
            BSEvents.levelQuit += OnSongExit;
            BSEvents.levelRestarted += OnSongExit;
            BSEvents.songPaused += OnPause;
            BSEvents.songUnpaused += OnUnpause;


        }

        public void OnPause()
        {
            Logger.log.Info("Song Paused");

        }

        public void OnUnpause()
        {
            Logger.log.Info("Song Unpaused");
        }

        public void OnGameSceneLoaded()
        {

            Logger.log.Info("1 GameSceneLoaded called");
            //evelData = new LevelData();


            if (statKeeper == null)
            {
                statKeeper = new StatKeeper();
            }
            else
            {
                Logger.log.Warn("E Statkeeper already exists.");
            }

        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Logger.log.Info("OnSceneLoaded: " + scene.name + " (" + mode + ")");
        }

        private void OnSceneUnloaded(Scene scene)
        {
            Logger.log.Info("OnSceneUnloaded: " + scene.name);
        }

        private void OnActiveSceneChanged(Scene previous, Scene current)
        {
            Logger.log.Info("OnActiveSceneChanged: " + previous.name + " -> " + current.name);
        }

        private void OnSongExit(StandardLevelScenesTransitionSetupDataSO data, LevelCompletionResults resuts)
        {
            Logger.log.Info("3 Song ended");
            if (statKeeper != null)
            {
                List<string> songStatList = statKeeper.GetSongStatsheet();
                //string songStats = statKeeper.GetSongStats();
                string filename = string.Join("_", statKeeper.songName, statKeeper.songDifficulty, ".txt");
                string path = Path.Combine(directory, filename);

                SaveSongStats(path, songStatList);
                statKeeper.ClearStats();
                statKeeper = null;

            }

            if (statKeeper == null)
                Logger.log.Info("7 Statkeeper deactivated.");
        }

        private void SaveSongStats(string path, List<string> statlist)
        {
            // Column headers added only once to the file.
            string header = "Note ID, Note Time, Note type, Direction, Lane, Level, X, Y, Z, Good Cut, " + DateTime.Now.ToString() + Environment.NewLine;

            File.AppendAllText(path, header);
            File.AppendAllLines(path, statlist);
            Logger.log.Info("5 Song stats saved to file.");

        }

        [OnEnable]
        public void OnEnable() => Load();

        [OnDisable]
        public void OnDisable() => Unload();

        private void Load()
        {
            AddEvents();
            Logger.log.Info($"{PluginName} has started.");
        }

        private void Unload()
        {
            RemoveEvents();
        }

        private void AddEvents()
        {
            RemoveEvents();
            BSEvents.gameSceneLoaded += OnGameSceneLoaded;
        }

        private void RemoveEvents()
        {
            BSEvents.gameSceneLoaded -= OnGameSceneLoaded;
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
