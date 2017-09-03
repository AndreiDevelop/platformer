using UnityEngine;
using System.Collections;
using TMPro;

public class TimeGameUI : MonoBehaviour 
{
    private TextMeshProUGUI _tekTMP;
    private TimeManager _gameTime;

	void OnEnable()
	{
		TimeManager.OnUpdateTime += UpdateTime;
	}

	void OnDisable()
	{
		TimeManager.OnUpdateTime -= UpdateTime;
	}

	// Use this for initialization
	void Start () 
    {
        _tekTMP = GetComponent<TextMeshProUGUI>();
        _gameTime = GameObject.FindObjectOfType<TimeManager>();
	}
	
	// Update is called once per frame
	void UpdateTime () 
    {
		if (_gameTime != null)
			_tekTMP.text = _gameTime.Minutes.ToString ("0#") + ":" + _gameTime.Seconds.ToString ("0#");
	}
}
