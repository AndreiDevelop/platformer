using UnityEngine;
using System.Collections;
using TMPro;

public class TimeGameUI : MonoBehaviour 
{
    private TextMeshProUGUI _tekTMP;
    private TimeManager _gameTime;

    public int seconds;

	// Use this for initialization
	void Start () 
    {
        _tekTMP = GetComponent<TextMeshProUGUI>();
        _gameTime = GameObject.FindObjectOfType<TimeManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        _tekTMP.text = _gameTime.Minutes.ToString("0#") + ":" + _gameTime.Seconds.ToString("0#");
	}
}
