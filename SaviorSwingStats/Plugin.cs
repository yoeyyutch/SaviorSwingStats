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
        internal static string Name => "SaviorSwingStats";
        internal static string SaveFolder = Path.Combine(UnityGame.UserDataPath + Name);

        readonly string directory = @"C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\UserData\SaviorSwingStats";

        readonly string myname = Path.Combine(Environment.CurrentDirectory, "UserData", Name, ".txt");


        // private LevelData levelData;
        private StatKeeper statKeeper;
        //BeatmapObjectSpawnController _spawnController;

        [Init]
        public void Init(IPALogger logger)
        {

            Logger.log = logger;
        }

        [OnStart]
        public void OnApplicationStart()
        {
            Directory.CreateDirectory(FileManager.StatsDirectory);

            // Creates a new SwingData object to hold swing stats for the song being played
            BSEvents.gameSceneLoaded += GameSceneLoaded;

            // At the end of the level, the SwingsData stats are saved to a file
            BSEvents.levelCleared += SongEnded;
            BSEvents.levelFailed += SongEnded;
            BSEvents.levelQuit += SongEnded;
            BSEvents.levelRestarted += SongEnded;
        }

        public void GameSceneLoaded()
        {
            Logger.log.Info("1 GameSceneLoaded called");
            //evelData = new LevelData();
            if (statKeeper == null)
                statKeeper = new StatKeeper();
            else
                Logger.log.Warn("E Statkeeper already exists.");
        }


        private void SongEnded(StandardLevelScenesTransitionSetupDataSO data, LevelCompletionResults resuts)
        {
            Logger.log.Info("3 Song ended");
            if (statKeeper != null)
            {
                List<string> songStatList = statKeeper.GetSongStatsheet();
                //string songStats = statKeeper.GetSongStats();
                string path = directory + @"\" + statKeeper.songName + "_" + statKeeper.songDifficulty + ".txt";
                SaveSongStats(path, songStatList);
                statKeeper.ClearStats();
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

            string header = "Note ID,Note hit,Note Time, Direction, Lane, Level, Miss Distance, Time Deviation, Combo, Before Cut Rating, After CutRating, " + DateTime.Now.ToString() + Environment.NewLine;



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
