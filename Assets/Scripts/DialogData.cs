﻿using System;

namespace AssemblyCSharp
{
	public class DialogData
	{
		public Speech[] test, revere, washington, hancock, mail, henry;
		public Speech[] impeach, readmit, grant;
		public Speech[] einstein, lusitania;
		public Speech[] houdini, sat;
		public DialogData (){
			Speech test1 = new Speech ("temp1", "Dang Anesu that's so cool", "temp1");
			Speech test2 = new Speech ("temp2", "Awww thanks guys", "temp2");
			Speech test3 = new Speech ("temp1", "You really are the best", "temp1");
			test =  new Speech[]{test1, test2, test3};

			Speech revere1 = new Speech ("APRIL","Paul Revere completes his midnight ride to Lexington to give warning of the British invasion", "revere");
			revere = new Speech[] {revere1};
			Speech washington1 = new Speech("APRIL", "George Washington is named supreme commander by the 2nd Continental Congress", "washington");
			washington = new Speech[]{washington1};
				Speech hancock1 = new Speech("MAY","John Hancock is selected as the president of the Continetal Congress", "hancock");
			hancock = new Speech[]{hancock1};
					Speech henry1 = new Speech("MAY","Patrick Henry proclaims: 'Give me liberty or give me death' in a speech advocating for Virginia's involvement in the Revolutionary war", "henry");
			henry = new Speech[]{henry1};
					Speech mail1 = new Speech("JUNE","The United States Postal Service is created under Benjamin Franklin", "franklin");
			mail = new Speech[]{mail1};

			Speech impeach1 = new Speech("FEBRUARY","The US House of Representatives votes 126-47 to impeach president Andrew Johnson", "impeach");
			impeach = new Speech[]{impeach1};
			Speech readmit1 = new Speech ("JUNE", "Florida, Alabama, Louisiana, Georgia, North Carolina and South Carolina are readmitted into the Union", "readmit"); 
			readmit = new Speech[]{readmit1};
			Speech grant1 = new Speech ("NOVEMBER", "Ulysses Grant wins presidency over Horatio Seymour", "grant"); 
			grant = new Speech[]{grant1};

			Speech e1 = new Speech ("NOVEMBER", "Einstein completes his general theory of relativity", "einstein"); 
			einstein = new Speech[]{e1};
			Speech l1 = new Speech ("MAY", "A U-Boat sink British liner Lusitania with the loss of American lives, creating a US-German diplomatic crisis", "lusitania"); 
			lusitania = new Speech[]{l1};

			Speech h1 = new Speech ("OCTOBER", "The legendary escape artist Harry Houdini dies at the age of 52", "houdini"); 
			houdini = new Speech[]{h1};
			Speech s1 = new Speech ("JUNE", "The first SAT test is administered to high school students", "sat"); 
			sat = new Speech[]{s1};


		}
			
	}
}

