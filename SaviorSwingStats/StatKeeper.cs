//using BS_Utils.Gameplay;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BS_Utils.Utilities;
using System;
//using Newtonsoft.Json;

namespace SaviorSwingStats
{
    public class StatKeeper
    {
        public string songName, songDifficulty;
        public int songNoteCount;
        private List<string> statsheet = new List<string>();
        //private readonly List<Statline> statlines = new List<Statline>();

        private Statline statline = new Statline();

        private readonly ScoreController _scoreController;
        public ScoreController GetScoreController() => _scoreController;

        private readonly GameplayCoreSceneSetupData _sceneData;
        public GameplayCoreSceneSetupData GetSceneData() => _sceneData;

        //private readonly BeatmapObjectSpawnController _spawnController;
        //public BeatmapObjectSpawnController GetSpawnController() => _spawnController;
        //private readonly NoteController _noteController;
        //public NoteController GetNoteController() => _noteController;

        public StatKeeper()
        {
            Logger.log.Info("2 New statkeeper active.");
            //statsheet.Clear();
            _scoreController = Resources.FindObjectsOfTypeAll<ScoreController>().First();
            _sceneData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData;
            //_spawnController = Resources.FindObjectsOfTypeAll<BeatmapObjectSpawnController>().First();
            songDifficulty = _sceneData.difficultyBeatmap.difficulty.ToString().ToLower();
            songName = _sceneData.difficultyBeatmap.level.songName;
            songNoteCount = _sceneData.difficultyBeatmap.beatmapData.notesCount;
            //_noteController = Resources.FindObjectsOfTypeAll<NoteController>().First();
            GetScoreController().noteWasCutEvent += OnNoteCut;
            GetScoreController().noteWasMissedEvent += OnNoteMissed;
 
        }

        public void OnNoteCut(NoteData note, NoteCutInfo cutInfo, int multiplier)
        {
            if (note.noteType == NoteType.Bomb)
                return;

            else
            {
                statline = new Statline(note.id+1, cutInfo.allIsOK, note.time, (int)note.noteType, note.cutDirection.ToString(), note.lineIndex, (int)note.noteLineLayer, cutInfo.cutDistanceToCenter, cutInfo.timeDeviation, multiplier, cutInfo.swingRatingCounter.beforeCutRating, cutInfo.swingRatingCounter.afterCutRating);

                statsheet.Add(statline.GetStatline());
            }
        }

        public void OnNoteMissed(NoteData note, int multiplier)
        {
            if (note.noteType == NoteType.Bomb)
                return;
            else
            {
                statline = new Statline(note.id+1, false, note.time, (int)note.noteType, note.cutDirection.ToString(), note.lineIndex, (int)note.noteLineLayer, 10f, 10f, multiplier, 0f,0f);

                statsheet.Add(statline.GetStatline());

            }
        }

        //public string GetSongStats()
        //{
        //    string songStats = string.Join("\n", statsheet);
        //    Logger.log.Info("GetSongStats called.");

        //    return songStats;
        //}
        public List<string> GetSongStatsheet()
        {
            Logger.log.Info("4 GetSongStatSheetCalled");
            return statsheet;
        }

        public void ClearStats()
        {
            Logger.log.Info("6 Stats cleared");

            statsheet.Clear();
        }
    }
}
//public void OnNoteCut(NoteController noteController, NoteCutInfo cutInfo)
//{
//    NoteData data = noteController.noteData;
//    //Vector3 center = noteController.noteTransform.position;
//    //Vector3 localCutPoint = cutInfo.cutPoint - center;
//    Logger.log.Info($"{data.id},{data.cutDirection},{data.lineIndex},{data.noteLineLayer},{cutInfo.cutDistanceToCenter.ToString()}");
//missDistance.Add(cut.cutDistanceToCenter);
//Logger.log.Info(missDistance[missDistance.Count - 1].ToString());
//}
//textline[noteIndex] = string.Join(",", swing);
//NoteData data = noteController.noteData;
//Logger.log.Info($"{data.id}");

