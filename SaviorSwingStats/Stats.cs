using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SaviorSwingStats
{
    public struct Stats
    {
        
        public NoteData NoteData;
        public NoteCutInfo NoteCutInfo;
        public Vector3 NotePosition;

        public Stats(INoteController controller, NoteData noteData, NoteCutInfo noteCutInfo, Vector3 notePosition)
        {
            NoteData = noteData;
            NoteCutInfo = noteCutInfo;
            NotePosition = notePosition;
        }

        public Stats(NoteData noteData)
        {
          
            NoteData = noteData;
            NoteCutInfo = null;
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
