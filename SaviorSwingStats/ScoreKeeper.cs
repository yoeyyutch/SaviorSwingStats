using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SaviorSwingStats
{
    class ScoreKeeper
    {
        private List<string> scoresheet = new List<string>();
        private Scoreline scoreline = new Scoreline();

        private readonly ScoreController _scoreController;
        public ScoreController GetScoreController() => _scoreController;

        //private BeatmapObjectSpawnController _spawnController;
        //public BeatmapObjectSpawnController GetSpawnController() => _spawnController;
        //private readonly NoteController _noteController;
        //public NoteController GetNoteController() => _noteController;

        public ScoreKeeper()
        {
            Logger.log.Info("2 New scorekeeper active.");
            //statsheet.Clear();
            _scoreController = Resources.FindObjectsOfTypeAll<ScoreController>().First();
            //_noteController = Resources.FindObjectsOfTypeAll<NoteController>().First();
            GetScoreController().scoreDidChangeEvent += OnScoreChange;
            GetScoreController().noteWasMissedEvent += OnNoteMissed;
        }

        public void OnScoreChange(int rawScore, int modifiedScore)
        {
            if (note.noteType == NoteType.Bomb)
                return;

            else
            {
                scoreline = new Scoreline();

                statsheet.Add(statline.GetStatline());
            }
        }

        public void OnNoteMissed(NoteData noteData, int multiplier)
        {

        }
    }
}
