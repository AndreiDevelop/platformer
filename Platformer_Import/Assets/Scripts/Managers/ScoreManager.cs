using UnityEngine;
using System.Collections;

public class ScoreManager
{
	public delegate void UpdateScore();
	public static event UpdateScore OnUpdateScore;

    private static int _tekScore;
    public static int TekScore
    {
        get
        {
			return _tekScore;
        }
        set
        {
			_tekScore = (value >=0) ? value : 0;

			if (OnUpdateScore != null)
				OnUpdateScore ();
        }
    }
}
