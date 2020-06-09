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

        private readonly GameplayCoreSceneSetupData _sceneData;
        public GameplayCoreSceneSetupData GetSceneData() => _sceneData;

        public SongInfo() { }
    }
}
