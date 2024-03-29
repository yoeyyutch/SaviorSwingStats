﻿//using BS_Utils.Gameplay;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BS_Utils.Utilities;
using System;
using Object = UnityEngine.Object;
//using Newtonsoft.Json;

namespace SaviorSwingStats
{
	public class StatKeeper
	{
		private readonly MyBeatmapObjectManager beatmapObjectManager;
		private readonly List<SliceData> statsheet = new List<SliceData>();

		internal StatKeeper()
		{
			beatmapObjectManager.noteWasCutEvent += OnNoteCut;
		}

		public List<SliceData> Statsheet => statsheet;

		private void OnNoteCut(NoteController noteController, in NoteCutInfo noteCutInfo)
		{
			if (noteController.noteData.colorType == ColorType.None || !noteCutInfo.allIsOK) return;
			SliceData slice = new SliceData(noteController.noteData, noteCutInfo, noteController.transform.position);
			statsheet.Add(slice);
		}


	}
}
/*
		public GameObject CutChart;
		public List<GameObject> cutPoints;

		public string songName, songDifficulty;
		public int songNoteCount;
		private List<string> statsheet = new List<string>();
		private int cutNumber;
		private Quaternion gridRotation = Quaternion.Euler(90f, 0f, 0f);

		// private Statline statline = new Statline();
		// private SongStats songStats = new SongStats();
		//public bool _statkeeperActive;
		//private static List<Vector3> cuts = new List<Vector3>();
		//private readonly List<Statline> statlines = new List<Statline>();

		private readonly ScoreController scoreController;
		public ScoreController GetScoreController() => scoreController;

		private readonly GameplayCoreSceneSetupData _sceneData;
		public GameplayCoreSceneSetupData GetSceneData() => _sceneData;

		//private readonly BeatmapObjectSpawnController BOSC;
		//public BeatmapObjectSpawnController GetBOSC() => BOSC;

		private readonly MyBeatmapObjectManager mbom;

		//private readonly BeatmapObjectManager beatmapObjectManager;
		//public BeatmapObjectManager GetBOM() => beatmapObjectManager;


		public StatKeeper()
		{
			Logger.log.Info("2 New statkeeper active.");
			CutChart = new GameObject();
			Object.DontDestroyOnLoad(CutChart);
			//Utilities.SetGameObjectTransform(CutChart, Vector3.zero, Quaternion.identity, Vector3.zero);
			CutChart.SetActive(true);

			//CutChart.transform.position = Vector3.zero;
			CutChart.transform.localScale = Vector3.one;
			//CutChart.transform.rotation = Quaternion.identity;
			CutChart.transform.SetPositionAndRotation(Vector3.zero, gridRotation);

			CutChart.transform.localScale = Vector3.zero;

			cutPoints = new List<GameObject>();

			scoreController = Resources.FindObjectsOfTypeAll<ScoreController>().First();
			_sceneData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData;
			var data = _sceneData.difficultyBeatmap.beatmapData.beatmapObjectsData;
			foreach (BeatmapObjectData beatmapObject in data)
			{
				if (beatmapObject is NoteData noteData)
				{
					bool x = true;
				}
			}

			//BOSC = Resources.FindObjectsOfTypeAll<BeatmapObjectSpawnController>().First();

			songDifficulty = _sceneData.difficultyBeatmap.difficulty.ToString().ToLower();
			songName = _sceneData.difficultyBeatmap.level.songName;
			songNoteCount = _sceneData.difficultyBeatmap.beatmapData.cuttableNotesCount;

			//scoreController.noteWasCutEvent += OnNoteCutSC;
			//scoreController.noteWasMissedEvent += OnNoteMissed;
			//mbom.HandleNoteControllerNoteWasCut += OnNoteCut;
			mbom.noteWasCutEvent += OnNoteWasCut;
			mbom.noteWasMissedEvent += OnNoteWasMissed;


			//BSEvents.songPaused += OnPause;
			//BSEvents.songUnpaused += UnPause;

		}

		private void OnNoteWasMissed(NoteController obj)
		{
			throw new NotImplementedException();
		}

		private void OnNoteWasCut(NoteController noteController, in NoteCutInfo noteCutInfo)
		{
			if (noteController.noteData.colorType == ColorType.None || !noteCutInfo.allIsOK) return;
		}

		private void LogSliceData(NoteController noteController, NoteCutInfo noteCutInfo)
		{

		}

		public void OnNoteCut(NoteController noteController, NoteCutInfo cutInfo)
		{
			if (noteController.noteData.colorType == ColorType.None || !cutInfo.allIsOK) return;

			Vector3 centerOfNote = noteController.noteTransform.position;

			Vector3 centerOFCut = cutInfo.cutPoint - centerOfNote;

			//float cutMiss = 0f;
			SliceData sliceData = new SliceData(note, cutInfo, centerOfNote);

			Statline statline = new Statline(
				number: cutNumber,
				goodCut: cutInfo.allIsOK,
				time: note.time,
				type: (int)note.colorType,
				direction: note.cutDirection.ToString(),
				column: note.lineIndex + 1,
				row: (int)note.noteLineLayer + 1,
				cutDeviation: cutInfo.cutDistanceToCenter,
				cutTimeOff: cutInfo.timeDeviation,
				noteCenter: centerOfNote,
				cutCenter: cutInfo.cutPoint,
				cutPlaneNormal: cutInfo.cutNormal);


			statsheet.Add(statline.GetStatline());


			DrawDot
				(
				index: cutNumber,
				notetype: (int)note.colorType,
				cutPosition: cutInfo.cutPoint,
				scaleFactor: 0.01f,
				shader: "Custom/Glowing",
				missDistance: cutInfo.cutDistanceToCenter,
				cutNormal: cutInfo.cutNormal
				);
			cutNumber++;



		}
	}

	public void OnNoteMissed(NoteData note, int multiplier)
	{
		if (note.colorType == ColorType.None)
			return;
		else
		{
			Statline statline = new Statline(
				number: 1,
				goodCut: false,
				time: note.time,
				type: (int)note.colorType,
				direction: note.cutDirection.ToString(),
				column: note.lineIndex + 1,
				row: (int)note.noteLineLayer + 1,
				cutDeviation: 10f,
				cutTimeOff: 10f,
				noteCenter: Vector3.zero,
				cutCenter: Vector3.zero,
				cutPlaneNormal: Vector3.zero);

			statsheet.Add(statline.GetStatline());
		}
	}

	public void DrawDot(int index, int notetype, Vector3 cutPosition, float scaleFactor, string shader, float missDistance, Vector3 cutNormal)
	{
		float p = Mathf.Atan2(-1f * cutNormal.x, cutNormal.y) * Mathf.Rad2Deg;
		Quaternion dotRotation = Quaternion.Euler(90f, 0f, p);
		Vector3 dotScale = new Vector3(missDistance, scaleFactor, scaleFactor);

		cutPoints.Insert(index, GameObject.CreatePrimitive(PrimitiveType.Cube));
		cutPoints[index].SetActive(true);
		cutPoints[index].transform.SetParent(CutChart.transform);
		cutPoints[index].transform.position = new Vector3(cutPosition.x, -.5f, cutPosition.y + 1f);
		cutPoints[index].transform.rotation = dotRotation;
		cutPoints[index].transform.localScale = dotScale;

		float r = notetype == 0 ? .75f : 0f;
		float b = notetype == 1 ? .75f : 0f;
		float a = 1 - Mathf.Clamp01(missDistance / 0.3f);
		Color gradient = new Color(r, 0f, b, 1f);
		Renderer renderer = cutPoints[index].GetComponent<Renderer>();
		renderer.material = SetMaterial(gradient, shader);



	}

	private Material SetMaterial(Color color, string shader)
	{
		Material output;
		//Material shaderCheck = new Material(Shader.Find("Custom/Glowing")); 
		Material shaderCheck = new Material(Shader.Find(shader));
		if (shaderCheck == null)
		{
			Material missingMaterial = new Material(Shader.Find("Custom/Glowing"));
			output = missingMaterial;
		}

		else
		{
			output = shaderCheck;
		}

		output.name = "Cut_Material";
		output.SetColor("_Color", color);

		//Logger.log.Info("Matl : " + output.name);
		//Logger.log.Info("Shader    : " + output.shader.name);

		return output;
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

	public void Clearcuts()
	{
		Logger.log.Info(" Cutpoints cleared");
		cutPoints.Clear();
		cutNumber = 0;
	}
}
}*/

class MyBeatmapObjectManager : BeatmapObjectManager
{
	public override List<ObstacleController> activeObstacleControllers => throw new NotImplementedException();

	protected override ObstacleController SpawnObstacleInternal(ObstacleData obstacleData, BeatmapObjectSpawnMovementData.ObstacleSpawnData obstacleSpawnData, float rotation)
	{
		throw new NotImplementedException();
	}

	protected override NoteController SpawnBombNoteInternal(NoteData noteData, BeatmapObjectSpawnMovementData.NoteSpawnData noteSpawnData, float rotation)
	{
		throw new NotImplementedException();
	}

	protected override NoteController SpawnBasicNoteInternal(NoteData noteData, BeatmapObjectSpawnMovementData.NoteSpawnData noteSpawnData, float rotation, float cutDirectionAngleOffset)
	{
		throw new NotImplementedException();
	}

	protected override void DespawnInternal(NoteController noteController)
	{
		throw new NotImplementedException();
	}

	protected override void DespawnInternal(ObstacleController obstacleController)
	{
		throw new NotImplementedException();
	}

	public override void DissolveAllObjects()
	{
		throw new NotImplementedException();
	}

	public override void HideAllBeatmapObjects(bool hide)
	{
		throw new NotImplementedException();
	}

	public override void PauseAllBeatmapObjects(bool pause)
	{
		throw new NotImplementedException();
	}
}

//public void ClearGrid()
//{
//    if(notegrid != null)
//    {
//        notegrid = null;
//    }
//}

//private bool IsCenterLeftOfCut(Vector3 cutPlaneNormal, Vector3 cutPoint)
//{
//    Vector3 lineNormal = new Vector3(cutPlaneNormal.x, cutPlaneNormal.y);
//    return Vector3.Dot(lineNormal, -cutPoint) > 0f;
//}

//NoteCutDirection directionType = data.cutDirection;
//float cutMiss = ProcessMissDistanceAndDirection(localCutPoint, 
//note.cutDirection) ? cutInfo.cutDistanceToCenter : -cutInfo.cutDistanceToCenter;

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


//public bool ProcessMissDistanceAndDirection(Vector3 localCutPoint, NoteCutDirection direction)
//{
//    int d = (int)direction;
//    bool misIsMoreRightThanAbove = Math.Abs(localCutPoint.x) > Math.Abs(localCutPoint.y);
//    bool isRight = localCutPoint.x > 0;
//    bool isAbove = localCutPoint.y > 0;
//    bool output;

//    if (d == 2 || d == 3)
//        output = isAbove ? true : false;

//    else if (d == 8)
//    {
//        if (misIsMoreRightThanAbove)
//            output = isRight ? true : false;
//        else
//            output = isAbove ? true : false;
//    }

//    else
//        output = isRight ? true : false;

//    return output;

//}
