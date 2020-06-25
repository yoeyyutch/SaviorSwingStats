using System;
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
		public Vector3 NoteCenter;
		public Vector3 CutCenter;
		public Vector3 CutPlaneNormal;

		public Statline(int number, bool goodCut, float time, int type, string direction, int column, int row, float cutDeviation, float cutTimeOff, Vector3 noteCenter, Vector3 cutCenter, Vector3 cutPlaneNormal)
		{
			Number = number;
			GoodCut = goodCut;
			Time = time;
			Type = type;
			Direction = direction;
			Column = column;
			Row = row;
			CutDeviation = cutDeviation;
			TimeDeviation = cutTimeOff;
			NoteCenter = noteCenter;
			CutCenter = cutCenter;
			CutPlaneNormal = cutPlaneNormal;
		}

		public string[] GetStatlineArray()
		{
			string[] array = new string[] {
				Number.ToString(),
				Time.ToString("0.0000"),
				Type == 0 ? "L":"R",
				Direction.ToString(),
				Column.ToString(),
				Row.ToString(),
				CutDeviation.ToString("0.00000"),
				TimeDeviation.ToString("0.00000"),
				GoodCut.ToString() };

			return array;
		}

		public string[] GetStatlineArray2()
		{
			string[] array = new string[] {
				Number.ToString(),
				Time.ToString("0.000"),
				Type == 0 ? "L":"R",
				DirectionAbbreviation(Direction),
				Column.ToString(),
				Row.ToString(),
				CutDeviation.ToString("0.000"),
				NoteCenter.ToString("F3"),
				CutCenter.ToString("F3"),
				TimeDeviation.ToString("0.000"),
				GoodCut.ToString()};
			return array;
		}



		public string[] GetStatlineArray3()
		{
			string[] array = new string[] {
				Number.ToString(),
				Time.ToString("0.000"),
				Type == 0 ? "A":"B",
				DirectionAbbreviation(Direction),
				Column.ToString(),
				Row.ToString(),
                //CutDeviation.ToString("0.000"),
                CutCenter.x.ToString("0.000"),
				CutCenter.y.ToString("0.000"),
				CutCenter.z.ToString("0.000"),
                //TimeDeviation.ToString("0.000"),
                GoodCut == true ? "T" : "F" };
			return array;
		}

		public string[] GetStatlineArray4()
		{
			string[] array = new string[] {
				Number.ToString("000"),
				Time.ToString("000.000"),
				Type == 0 ? "LH":"RH",
				DirectionAbbreviation(Direction),
				Column.ToString(),
				Row.ToString(),
				NoteCenter.x.ToString("0.000"),
				NoteCenter.y.ToString("0.000"),
				NoteCenter.z.ToString("0.000"),

				CutCenter.x.ToString("0.000"),
				CutCenter.y.ToString("0.000"),
				CutCenter.z.ToString("0.000"),

				CutPlaneNormal.x.ToString("0.000"),
				CutPlaneNormal.y.ToString("0.000"),
				CutPlaneNormal.z.ToString("0.000"),
				CutDeviation.ToString("0.000"),
				TimeDeviation.ToString("0.000"),
				GoodCut == true ? "T" : "F" };
			return array;
		}




		public string GetStatline()
		{
			string[] array = GetStatlineArray4();
			string statline = string.Join(", ", array);
			return statline;
		}

		private static string DirectionAbbreviation(string direction)
		{
			if (direction == "Up")
				return "Up_";
			else if (direction == "Down")
				return "Dn_";
			else if (direction == "Left")
				return "Lft";
			else if (direction == "Right")
				return "Rgt";
			else if (direction == "UpLeft")
				return "UpL";
			else if (direction == "UpRight")
				return "UpR";
			else if (direction == "DownLeft")
				return "DnL";
			else if (direction == "DownRight")
				return "DnR";
			else if (direction == "Any")
				return "Dot";
			else
				return "---";
		}
	}

	//public struct MissDirection
	//{
	//    public MissDirection()
	//    {

	//    }

	//}
}
