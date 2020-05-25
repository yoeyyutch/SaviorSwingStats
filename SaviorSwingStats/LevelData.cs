using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using BS_Utils.Gameplay;
using UnityEngine;

namespace SaviorSwingStats
{
    class LevelData
    {
        public Dictionary<string, IRecorder> recorders = new Dictionary<string, IRecorder>()
        {
            {"Swing Rating Recorder", new SwingRatingRecorder()}
        };

        private readonly BeatmapObjectExecutionRatingsRecorder beatmapObjectExecutionRatingsRecorder;
        public BeatmapObjectExecutionRatingsRecorder GetBeatmapObjectExecutionRatingsRecorder() => beatmapObjectExecutionRatingsRecorder;

        private readonly ScoreController scoreController; public ScoreController GetScoreController() => scoreController;

        public LevelData()
        {
            beatmapObjectExecutionRatingsRecorder = Resources.FindObjectsOfTypeAll<BeatmapObjectExecutionRatingsRecorder>().First();

            scoreController = Resources.FindObjectsOfTypeAll<ScoreController>().First();

            foreach (IRecorder recorder in recorders.Values)
                recorder.StartRecording(this);

        }

        public string FinalizeData(LevelCompletionResults results)
        {

            return JsonConvert.SerializeObject(this);

        }
    }
}
