using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour 
{
    private int _timeInSecondsSinceGameStart;
	public int TimeInSecondsSinceStartGame
	{
		get 
		{
			return _timeInSecondsSinceGameStart;
		}
	}

    private int _minutes;
    public int Minutes
    {
        get
        {
            return _minutes;
        }
    }
        
    private int _seconds;
    public int Seconds
    {
        get
        {
            return _seconds;
        }
    }

	private bool _timerActive = false;

    void Start()
    {
        _timeInSecondsSinceGameStart = 0;
        StartTimeCounter();
    }

	// Update is called once per frame
	void Update () 
    {
        if (_timerActive)
            timer();
	}

    void timer()
    {
        _seconds = (int)(_timeInSecondsSinceGameStart % 60f);
        _minutes = (int)(_timeInSecondsSinceGameStart / 60f);
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
            yield return new WaitForSeconds(1f);
            _timeInSecondsSinceGameStart++;
        }
    }

    public void ResetTimeCounter()
    {
        _timeInSecondsSinceGameStart = 0;
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
