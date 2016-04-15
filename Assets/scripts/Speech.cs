using System;

namespace AssemblyCSharp
{
	public class Speech
	{
		private string message, src, id;
		private UnityEngine.Sprite icon;

		public Speech (string src, string message, string id)
		{
			this.src = src;
			this.message = message;
			icon = Media.getIcon (id);
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

