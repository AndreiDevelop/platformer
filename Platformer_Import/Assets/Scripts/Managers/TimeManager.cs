using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour 
{
	public delegate void UpdateTime();
	public static event UpdateTime OnUpdateTime;

    private static int _timeInSecondsSinceGameStart;
	public static int TimeInSecondsSinceStartGame
	{
		get 
		{
			return _timeInSecondsSinceGameStart;
		}
		private set 
		{
			_timeInSecondsSinceGameStart = (value >= 0) ? value : 0;

			if (OnUpdateTime != null)
				OnUpdateTime ();
		}
	}

    public int Minutes
    {
        get
        {
			return TimeInSecondsSinceStartGame / 60;
        }
    }
        
    public int Seconds
    {
        get
        {
			return TimeInSecondsSinceStartGame % 60;
        }
    }

	private bool _timerActive = false;

    void Start()
    {
		TimeInSecondsSinceStartGame = 0;
        StartTimeCounter();
    }

    public void StartTimeCounter()
    {
        _timerActive = true;
        StartCoroutine(timerCounter());
    }

    IEnumerator timerCounter()
    {
        while (_timerActive)
        {
            yield return new WaitForSeconds(1);
			TimeInSecondsSinceStartGame++;
        }
    }

    public void ResetTimeCounter()
    {
		TimeInSecondsSinceStartGame = 0;
    }

    public void StorTimeCounter()
    {
        _timerActive = false;
    }

    public void ContinueTimeCounter()
    {
        StartTimeCounter();
    }
}
