using System;

namespace AssemblyCSharp
{
	public class Speech
	{
		private string message, src;
		private UnityEngine.Sprite icon;

		public Speech (string message, string src, UnityEngine.Sprite icon)
		{
			this.src = src;
			this.message = message;
			this.icon = icon;
		}

		public string getMsg(){
			return message;
		}

		public string getSrc(){
			return src;
		}

		public UnityEngine.Sprite getIcon(){
			return icon;
		}
	}
}

