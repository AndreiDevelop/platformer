using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	public delegate void UpdateScore();
	public static event UpdateScore OnUpdateScore;

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
