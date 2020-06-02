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
        private readonly List<Statline> statlines = new List<Statline>();

        private Statline statline = new Statline();

        private readonly ScoreController _scoreController;
        public ScoreController GetScoreController() => _scoreController;

        private readonly GameplayCoreSceneSetupData _sceneData;
        public GameplayCoreSceneSetupData GetSceneData() => _sceneData;


        private readonly BeatmapObjectManager _BOM;
        public BeatmapObjectManager GetBOM() => _BOM;

        private readonly NoteController _noteController;
        public NoteController GetNoteController() => _noteController;

        public StatKeeper()
        {
            Logger.log.Info("2 New statkeeper active.");
            //statsheet.Clear();
            _scoreController = Resources.FindObjectsOfTypeAll<ScoreController>().First();
            _sceneData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData;
            _BOM = Resources.FindObjectsOfTypeAll<BeatmapObjectManager>().First();

            //_spawnController = Resources.FindObjectsOfTypeAll<BeatmapObjectSpawnController>().First();
            songDifficulty = _sceneData.difficultyBeatmap.difficulty.ToString().ToLower();
            songName = _sceneData.difficultyBeatmap.level.songName;
            songNoteCount = _sceneData.difficultyBeatmap.beatmapData.notesCount;

            //GetScoreController().noteWasCutEvent += OnNoteCut;
            GetScoreController().noteWasMissedEvent += OnNoteMissed;

            GetBOM().noteWasCutEvent += OnNoteCut;
            //GetBOM().noteWasMissedEvent += OnNoteMissed;


        }

        //public void OnNoteCut(NoteData note, NoteCutInfo cutInfo, int multiplier)
        //{
        //    if (note.noteType == NoteType.Bomb)
        //        return;

        //    else
        //    {
        //        statline = new Statline(note.id+1, cutInfo.allIsOK, note.time, (int)note.noteType, note.cutDirection.ToString(), note.lineIndex, (int)note.noteLineLayer, CutAccuracy(cutInfo.cutDistanceToCenter), cutInfo.timeDeviation, multiplier, cutInfo.swingRatingCounter.beforeCutRating, cutInfo.swingRatingCounter.afterCutRating);

        //        statlines.Add(statline);
        //    }
        //}

        public void OnNoteCut(INoteController noteController, NoteCutInfo cutInfo)
        {
            NoteData note = noteController.noteData;
            if (note.noteType == NoteType.Bomb)
                return;

            else
            {
                Vector3 center = noteController.noteTransform.position;
                Vector3 localCutPoint = cutInfo.cutPoint - center;
                //NoteCutDirection directionType = data.cutDirection;
                float cutMiss = IsCenterLeftOfCut(cutInfo.cutNormal, localCutPoint) ?  cutInfo.cutDistanceToCenter : -1f* cutInfo.cutDistanceToCenter;

                statline = new Statline(note.id + 1, cutInfo.allIsOK, note.time, (int)note.noteType, note.cutDirection.ToString(), note.lineIndex, (int)note.noteLineLayer, cutMiss, cutInfo.timeDeviation, 0, cutInfo.swingRatingCounter.beforeCutRating, cutInfo.swingRatingCounter.afterCutRating);

                statsheet.Add(statline.GetStatline());
            }

        }


        public void OnNoteMissed(NoteData note, int multiplier)
        {
            if (note.noteType == NoteType.Bomb)
                return;
            else
            {
                statline = new Statline(note.id + 1, false, note.time, (int)note.noteType, note.cutDirection.ToString(), note.lineIndex, (int)note.noteLineLayer, 10f, 10f, multiplier, 0f, 0f);

                statsheet.Add(statline.GetStatline());
            }
        }

        private bool IsCenterLeftOfCut(Vector3 cutPlaneNormal, Vector3 cutPoint)
        {
            Vector3 lineNormal = new Vector3(cutPlaneNormal.x, cutPlaneNormal.y);
            return Vector3.Dot(lineNormal, -cutPoint) > 0f;
        }

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

        //public string GetSongStats()
        //{
        //    string songStats = string.Join("\n", statsheet);
        //    Logger.log.Info("GetSongStats called.");

        //    return songStats;
        //}
        //public void UpdateSlice(Vector3 cutPoint, Vector3 cutPlaneNormal, NoteCutDirection noteDirectionType)
        //{
        //    cutPoint = new Vector3(cutPoint.x, cutPoint.y);

        //    Vector3 cutDirection = new Vector3(-cutPlaneNormal.y, cutPlaneNormal.x).normalized;
        //    float cutRotation = Mathf.Atan2(cutDirection.y, cutDirection.x) * Mathf.Rad2Deg;


        //    float noteRotation = RotationFromNoteCutDirection(noteDirectionType);
        //    SetBackgroundRotation(noteRotation);


        //    bool isCenterIsLeft = IsCenterLeftOfCut(cutPlaneNormal, cutPoint);
        //    float missedAreaRotation = cutRotation - noteRotation + (isCenterIsLeft ? 180f : 0f);

        //    float cutPointDistance = cutPoint.magnitude;



        //}


        //private float CutAccuracy(float cutPointDistance)
        //{
        //    return Mathf.Clamp01(cutPointDistance / 0.3f);
        //}

        //private float RotationFromNoteCutDirection(NoteCutDirection cutDirection)
        //{

        //    switch (cutDirection)
        //    {
        //        case NoteCutDirection.Down: return 0f;
        //        case NoteCutDirection.DownRight: return 45f;
        //        case NoteCutDirection.Right: return 90f;
        //        case NoteCutDirection.UpRight: return 135f;
        //        case NoteCutDirection.Up: return 180f;
        //        case NoteCutDirection.UpLeft: return 225f;
        //        case NoteCutDirection.Left: return 270f;
        //        case NoteCutDirection.DownLeft: return 315f;
        //        default: return 0f;
        //    }
        //}
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

