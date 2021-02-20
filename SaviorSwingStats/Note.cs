using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine

namespace SaviorSwingStats
{
	class Note
	{
		private readonly BeatmapObjectManager BOM;
		
		public Note()
		{
			BOM = Resources.FindObjectsOfTypeAll<BeatmapObjectManager>().First();
			
		}
	}
}
