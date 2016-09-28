using NUnit.Framework;
using System;
using System.Collections.Generic;
//using BattleShip;

namespace BattleShipTest
{
	[TestFixture ()]
	public class TEST_HighScoreController
	{
		
		[Test ()]
		public void SaveAndLoad ()
		{
			Random rnd = new Random ();
			try
			{
				
				HighScoreController.LoadScores ();
			}
			catch (System.IO.FileNotFoundException e)
			{
				HighScoreController.SaveScores ();

			}

				
			List<HighScoreController.Score> HighScores = HighScoreController.GetScores;


			HighScoreController.Score NewScore = new HighScoreController.Score ();
			NewScore.Name = "Fre";
			NewScore.Value = rnd.Next ();

			HighScoreController.Score TestScore = new HighScoreController.Score();
			TestScore.Name = "BAD";
			Random rnd2 = new Random ();

			TestScore.Value = rnd2.Next ();

			if (HighScores.Count > 0)
			{
				
				HighScores [0] = NewScore;

			}
			else
			{
				HighScores.Add (NewScore);

			}

			if (HighScores.Count > 1)
			{


				HighScores [1] = TestScore;

			}
			else
			{
				
				HighScores.Add (TestScore);

			}

			HighScoreController.SaveScores ();
			// Alter second score to test that we are correctly destroying and re-reading.
			HighScores[1] = NewScore;

			HighScoreController.LoadScores ();
			HighScores = HighScoreController.GetScores;

			Assert.AreEqual (NewScore, HighScores [0]);
			Assert.AreEqual (TestScore, HighScores [1]);


		}
	}
}

