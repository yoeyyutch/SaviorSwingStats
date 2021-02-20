using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaviorSwingStats
{
    class SongInfo
    {
        public string songName;
        public string songDifficulty;
        public int songNoteCount;

        private readonly GameplayCoreSceneSetupData gcSceneSetupData;

        public SongInfo() 
        {

            gcSceneSetupData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData;
        }
    }
}
