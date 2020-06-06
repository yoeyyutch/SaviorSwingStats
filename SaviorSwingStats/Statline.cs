﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SaviorSwingStats
{
    public struct Statline
    {
        public int Number;
        public bool GoodCut;
        public float Time;
        public int Type;
        public string Direction;
        public int Column;
        public int Row;
        public float CutDeviation;
        public float TimeDeviation;
        public int Combo;
        public float BeforeCutScore;
        public float AfterCutScore;
        public Vector3 NoteCenter;
        public Vector3 CutCenter;

        public Statline(int number, bool goodCut, float time, int type, string direction, int column, int row, float cutCenterOff, float cutTimeOff, int comboX, float before, float after, Vector3 noteCenter, Vector3 cutCenter)
        {
            Number = number;
            GoodCut = goodCut;
            Time = time;
            Type = type;
            Direction = direction;
            Column = column;
            Row = row;
            CutDeviation = cutCenterOff;
            TimeDeviation = cutTimeOff;
            Combo = comboX;
            BeforeCutScore = before;
            AfterCutScore = after;
            NoteCenter = noteCenter;
            CutCenter = cutCenter;
        }

        public string[] GetStatlineArray()
        {
            string[] array = new string[] { Number.ToString(), GoodCut.ToString(), Time.ToString("0.0000"),
                Type == 0 ? "L":"R", Direction.ToString(), Column.ToString(), Row.ToString(),CutDeviation.ToString("0.00000"), TimeDeviation.ToString("0.00000"), Combo.ToString(), BeforeCutScore.ToString("0.00000"),AfterCutScore.ToString("0.00000")};
            return array;
        }

        public string[] GetStatlineArray2()
        {
            string[] array = new string[] { Number.ToString(), GoodCut.ToString(), Time.ToString("0.000"),
                Type == 0 ? "L":"R", Direction.ToString(), Column.ToString(), Row.ToString(),CutDeviation.ToString("0.00000"), TimeDeviation.ToString("0.000"),NoteCenter.ToString(),CutCenter.ToString()};
            return array;
        }

        public string GetStatline()
        {
            string[] array = GetStatlineArray2();
            string statline = string.Join(",", array);
            return statline;
        }
    }

    //public struct MissDirection
    //{
    //    public MissDirection()
    //    {

    //    }

    //}
}
