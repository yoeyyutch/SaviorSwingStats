using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaviorSwingStats
{
    struct Scoreline
    {
        int BeforeCutScore;
        int AfterCutScore;
        int AccuracyScore;

        public Scoreline(int beforeCutScore, int afterCutScore, int accuracyScore )
        {
            BeforeCutScore = beforeCutScore;
            AfterCutScore = afterCutScore;
            AccuracyScore = accuracyScore;
        }

        private String[] GetScorelineArray()
        {
            string[] array = new string[] { BeforeCutScore.ToString(), AfterCutScore.ToString(), AccuracyScore.ToString() };
            return array;
        }

        public string GetScoreline()
        {
            string score = string.Join(",", GetScorelineArray());
            return score;
        }
    }
}
