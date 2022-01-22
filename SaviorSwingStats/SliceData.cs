using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SaviorSwingStats
{

	public struct SliceData
	{

		public NoteData NoteStats;
		public NoteCutInfo CutStats;
		public Vector3 NotePosition;


		public SliceData(NoteData noteData, NoteCutInfo noteCutInfo, Vector3 notePosition)
		{
			NoteStats = noteData;
			CutStats = noteCutInfo;
			NotePosition = notePosition;
		}

		public SliceData(NoteData noteData)
		{
			NoteStats = noteData;
			CutStats = new NoteCutInfo();
			NotePosition = Vector3.zero;
		}

	}
}
//private readonly INoteController noteController;
//int ID;
//float Time;
//int Type;
//string Direction;
//int Lane;
//int Level;
//Vector3 Center;

//public NoteStats(INoteController noteController)
//{
//    ID = noteController.noteData.id;
//    Time = noteController.noteData.time;
//    Type = (int)noteController.noteData.noteType;
//    Direction = noteController.noteData.cutDirection.ToString();
//    Lane = noteController.noteData.lineIndex+1;
//    Level = (int)noteController.noteData.noteLineLayer;
//    Center = noteController.noteTransform.position;
//    this.noteController = noteController;
//}
//}
//}
