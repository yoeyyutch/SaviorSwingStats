using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SaviorSwingStats
{
    public struct AccuracyCalibrationStats
    {
        public Vector3 NotePosition;
        public Vector3 CutPointPosition;
        public NoteCutDirection NoteDirection;

        public AccuracyCalibrationStats(Vector3 notePosition, Vector3 cutPointPosition, NoteCutDirection noteDirection)
        {
            NotePosition = notePosition;
            CutPointPosition = cutPointPosition;
            NoteDirection = noteDirection;
        }

        public void GetMissDirection(AccuracyCalibrationStats ac)
        {
            int dir = (int)ac.NoteDirection;
        }

    }
}
    //Up = 0,
    //Down = 1,
    //Left = 2,
    //Right = 3,
    //UpLeft = 4,
    //UpRight = 5,
    //DownLeft = 6,
    //DownRight = 7,
    //Any = 8,
    //None = 9
