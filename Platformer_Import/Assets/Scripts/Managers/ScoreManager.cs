using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
    private int _tekScore;
    public int TekScore
    {
        get
        {
            return _tekScore;
        }
        set
        {
           _tekScore = value;
        }
    }

	// Use this for initialization
	void Start () 
    {
        _tekScore = 0;
	}
}
