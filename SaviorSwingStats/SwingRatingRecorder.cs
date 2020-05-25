using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaviorSwingStats
{
    class SwingRatingRecorder : IRecorder
    {
        public List<Statline> statsheet = new List<Statline>();

        public struct Statline
        {
            public int number;
            public bool goodCut;
            public float time;
            public int type;
            public int direction;
            public int row;
            public int column;
            public float cutCenterOff;
            public float cutTimeOff;
            public int comboX;

            public Statline(int number, bool goodCut, float time, int type, int direction, int row, int column, float cutCenterOff, float cutTimeOff, int comboX)
            {
                this.number = number;
                this.goodCut = goodCut;
                this.time = time;
                this.type = type;
                this.direction = direction;
                this.row = row;
                this.column = column;
                this.cutCenterOff = cutCenterOff;
                this.cutTimeOff = cutTimeOff;
                this.comboX = comboX;
            }
        }

        public void StartRecording(LevelData levelData)
        {
            levelData.GetScoreController().noteWasCutEvent += OnNoteCut;
            levelData.GetScoreController().noteWasMissedEvent += OnNoteMissed;
        }

        public void FinishRecording(LevelCompletionResults results)
        {
            Join(",", statsheet);
        }

        private void Join(string v, List<Statline> statsheet)
        {
            throw new NotImplementedException();
        }

        public void OnNoteCut(NoteData note, NoteCutInfo cutInfo, int multiplier)
        {
            if (note.noteType == NoteType.Bomb) return;

            Statline swing = new Statline
            {
                goodCut = cutInfo.allIsOK,
                number = note.id,
                time = note.time,
                type = (int)note.noteType,
                direction = (int)note.cutDirection,
                column = note.lineIndex,
                row = (int)note.noteLineLayer,
                cutCenterOff = cutInfo.cutDistanceToCenter,
                cutTimeOff = cutInfo.timeDeviation,
                comboX = multiplier
            };

            statsheet.Add(swing);
        }

        public void OnNoteMissed(NoteData note, int multiplier)
        {
            if (note.noteType == NoteType.Bomb) return;
            Statline swing = new Statline
            {
                goodCut = false,
                number = note.id,
                time = note.time,
                type = (int)note.noteType,
                direction = (int)note.cutDirection,
                column = note.lineIndex,
                row = (int)note.noteLineLayer,
                cutCenterOff = 1000f,
                cutTimeOff = 1000f,
                comboX = multiplier
            };

            statsheet.Add(swing);
        }

        public static string Join(string sep, IEnumerable<string> parts)
        {
            var sb = new StringBuilder();
            int i = 0;
            foreach (var part in parts)
            {
                if (i++ != 0) sb.Append(sep);
                sb.Append(part);
            }
            return sb.ToString();
        }

    }
}
