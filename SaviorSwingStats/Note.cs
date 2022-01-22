using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SaviorSwingStats
{
	public class Note : BeatmapObjectManager
	{
		
		public Note()
		{
			
		}

		public override HashSet<ObstacleController> activeObstacleControllers => throw new NotImplementedException();

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

		protected override void DespawnInternal(NoteController noteController)
		{
			throw new NotImplementedException();
		}

		protected override void DespawnInternal(ObstacleController obstacleController)
		{
			throw new NotImplementedException();
		}

		protected override NoteController SpawnBasicNoteInternal(NoteData noteData, BeatmapObjectSpawnMovementData.NoteSpawnData noteSpawnData, float rotation, float cutDirectionAngleOffset)
		{
			throw new NotImplementedException();
		}

		protected override NoteController SpawnBombNoteInternal(NoteData noteData, BeatmapObjectSpawnMovementData.NoteSpawnData noteSpawnData, float rotation)
		{
			throw new NotImplementedException();
		}

		protected override ObstacleController SpawnObstacleInternal(ObstacleData obstacleData, BeatmapObjectSpawnMovementData.ObstacleSpawnData obstacleSpawnData, float rotation)
		{
			throw new NotImplementedException();
		}
	}
}
