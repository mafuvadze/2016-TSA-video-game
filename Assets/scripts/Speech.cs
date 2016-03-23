using System;

namespace AssemblyCSharp
{
	public class Speech
	{
		private string message, src;
		private UnityEngine.Sprite icon;

		public Speech (string src, string message)
		{
			this.src = src;
			this.message = message;
			icon = Media.getIcon (src);
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

