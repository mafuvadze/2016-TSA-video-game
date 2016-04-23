using System;

namespace AssemblyCSharp
{
	public class SequenceData
	{
		
		public MessageSeq[] lever, control, info, guess, dialog;
		public SequenceData ()
		{
			control = new MessageSeq[]{
				new MessageSeq("press A and D to move left and right", 5f),
			};

			lever = new MessageSeq[]{
				new MessageSeq("press X to pull lever", -1f),
			};

			info = new MessageSeq[]{
				new MessageSeq("press X to view clue", -1f),
			};

			guess = new MessageSeq[]{
				new MessageSeq("what year is it?", -1f),
			};

			dialog = new MessageSeq[]{ 
				new MessageSeq("click inside dialog box to dismiss", -1f)};
		}
	}
}

