using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreGameUI : MonoBehaviour 
{
    private TextMeshProUGUI _tekTMP;

	void OnEnable()
	{
		ScoreManager.OnUpdateScore += UpdateScore;
	}

	void OnDisable()
	{
		ScoreManager.OnUpdateScore -= UpdateScore;
	}
	// Use this for initialization
	void Start () 
    {
        _tekTMP = GetComponent<TextMeshProUGUI>();
	}

	void UpdateScore()
	{
		_tekTMP.text = ScoreManager.Instance.TekScore.ToString();
	}
}
