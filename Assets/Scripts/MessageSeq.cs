using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class MessageSeq
	{
		private float duration;
		private string msg;
		public MessageSeq (string msg, float duration)
		{
			this.msg = msg;
			this.duration = duration;
		}

		public float getDuration(){
			return duration; 
		}

		public string getMsg(){
			return msg;
		}
	}
}

