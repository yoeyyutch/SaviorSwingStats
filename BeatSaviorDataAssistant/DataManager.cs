using IPA.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BeatSaviorDataAssistant
{
	public class DataManager
	{
		static public readonly string directory = Path.Combine(UnityGame.UserDataPath, Plugin.PluginName);
		static public float playerHeight = 1.5f;
		public NoteCutDirection n;
		//static public Vector3 notePosition

	}
}
