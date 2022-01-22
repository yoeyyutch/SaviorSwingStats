using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaviorSwingStats
{
    class SongInfo
    {
        public string songName { get; private set; }
        public string songDifficulty { get; private set; }
        public int songNoteCount { get; private set; }

        private readonly GameplayCoreSceneSetupData sceneSetupData;

        public SongInfo() 
        {
            sceneSetupData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData;
        }
    }
}
