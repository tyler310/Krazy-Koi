using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreHistory{

	private static int currentScore, highScore;

	public static int CurrentScore 
	{
		get 
		{
			return currentScore;
		}
		set 
		{
			currentScore = value;
		}
	}
	public static int HighScore 
	{
		get 
		{
			return highScore;
		}
		set 
		{
			highScore = value;
		}
	}
}
