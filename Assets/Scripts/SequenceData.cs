using System;

namespace AssemblyCSharp
{
	public class SequenceData
	{
		
		public MessageSeq[] control;
		public MessageSeq[] lever;
		public SequenceData ()
		{
			control = new MessageSeq[]{
				new MessageSeq("press A and D to move left and right", 5f),
			};

			lever = new MessageSeq[]{
				new MessageSeq("press X to pull lever", 5f),
			};
		}
	}
}

