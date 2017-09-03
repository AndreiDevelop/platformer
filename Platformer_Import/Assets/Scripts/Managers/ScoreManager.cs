using UnityEngine;
using System.Collections;

public class ScoreManager
{
	public delegate void UpdateScore();
	public static event UpdateScore OnUpdateScore;

	#region Singleton

	private static readonly ScoreManager _instance = new ScoreManager ();
	public static ScoreManager Instance
	{
		get 
		{
			return _instance;
		}
	}

	#endregion

    private int _tekScore;
    public int TekScore
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
