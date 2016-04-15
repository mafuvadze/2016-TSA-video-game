using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Media
	{
		public Media ()
		{}

		public static Sprite getIcon(string name){
			Sprite icon = Resources.Load<Sprite> ("Images/Characters/" + name);
			if (icon != null) {
				return icon;
			} else {
				return Resources.Load<Sprite> ("Images/outline");
			}
		}

		public static Sprite getImage(string name){
			Sprite icon = Resources.Load<Sprite> ("Images/" + name);
			if (icon != null) {
				return icon;
			} else {
				return getDefault ();
			}
		}

		public static Sprite getPrologueImage(string name){
			Sprite icon = Resources.Load<Sprite> ("Images/Prologue/" + name);
			if (icon != null) {
				return icon;
			} else {
				return getDefault ();
			}
		}

		public static GameObject getPrefab(string name){
			GameObject obj = Resources.Load<GameObject> ("Prefabs/" + name);
			return obj;
		}
			
		private static Sprite getDefault(){
			Sprite icon = Resources.Load<Sprite> ("Images/placeholder");
			return icon;
		}
	}
}

