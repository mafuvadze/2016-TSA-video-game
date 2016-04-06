using System;

namespace AssemblyCSharp
{
	public class SequenceData
	{
		
		public MessageSeq[] control;
		public SequenceData ()
		{
			control = new MessageSeq[]{
				new MessageSeq("press A and D to move left and right", 5f),
				new MessageSeq("press W to jump", 3.5f),
				new MessageSeq("press P to pause", 4f)
			};
		}
	}
}

