using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
//using BS_Utils;

namespace SaviorSwingStats
{
	class NoteTaker : MonoBehaviour
	{
		public static NoteTaker Instance { get; private set; }
		private ScoreController scoreController;
		
		public void TakeNotes()
		{
			scoreController = Resources.FindObjectsOfTypeAll<ScoreController>().LastOrDefault();
			scoreController.noteWasCutEvent += OnNoteCut;
			scoreController.noteWasMissedEvent += OnNoteMiss;
		}

		public void OnNoteCut(NoteData noteData, in NoteCutInfo cutInfo, int multiplier)
		{

		}

		public void OnNoteMiss(NoteData noteData, int multiplier)
		{

		}

	}
}
