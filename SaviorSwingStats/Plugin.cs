using IPA;
using IPALogger = IPA.Logging.Logger;
using BS_Utils.Utilities;
using UnityEngine;
using BeatSaberMarkupLanguage;
using System.Collections.Generic;
using System.IO;
using System;
using IPA.Utilities;


namespace SaviorSwingStats
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static string PluginName => "SaviorSwingStats";
        readonly string directory = Path.Combine(UnityGame.UserDataPath, Plugin.PluginName);

        private StatKeeper statKeeper;
        private Notegrid notegrid;

        [Init]
        public void Init(IPALogger logger) { Logger.log = logger; }

        [OnStart]
        public void OnApplicationStart()
        {
           
            //MaterialSwapper.GetMaterials();
            //MaterialSwapper.ReplaceMaterialsForGameObject(NoteGridGameObject);
 

            //Notegrid.OnLoad();
            Directory.CreateDirectory(directory);

            // Creates a new SwingData object to hold swing stats for the song being played
            // BSEvents.gameSceneLoaded += OnGameSceneLoaded;

            // At the end of the level, the SwingsData stats are saved to a file
            BSEvents.levelCleared += OnSongExit;
            BSEvents.levelFailed += OnSongExit;
            BSEvents.levelQuit += OnSongExit;
            BSEvents.levelRestarted += OnSongExit;
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

        public void OnGameSceneLoaded()
        {
            Logger.log.Info("1 GameSceneLoaded called");
            //evelData = new LevelData();


            if (statKeeper == null)
            {
                statKeeper = new StatKeeper();
            }
            else
                Logger.log.Warn("E Statkeeper already exists.");
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
                //string path = directory + @"\" + statKeeper.songName + "_" + statKeeper.songDifficulty + ".txt";
                SaveSongStats(path, songStatList);
                statKeeper.ClearStats();

                //statKeeper.ClearGrid();
                statKeeper._statkeeperActive = false;
                statKeeper = null;

            }

            if (statKeeper == null)
                Logger.log.Info("7 Statkeeper deactivated.");
        }

        //private void SaveSongStats(string path, string stats)
        //{
        //    using (StreamWriter sw = File.AppendText(path))
        //    {
        //        sw.WriteLine("****** Song completed at " + DateTime.Now);
        //        sw.WriteLine(stats);
        //    }
        //}
        private void SaveSongStats(string path, List<string> statlist)
        {
            // Column headers added only once to the file.

            string header = "Note ID, Note Time, Note type, Direction, Lane, Level, X, Y, Z, Good Cut, " + DateTime.Now.ToString() + Environment.NewLine;

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
