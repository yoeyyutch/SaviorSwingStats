using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaviorSwingStats
{
    interface IRecorder
    {
        void StartRecording(LevelData levelData);
        void FinishRecording(LevelCompletionResults results);
    }
}
