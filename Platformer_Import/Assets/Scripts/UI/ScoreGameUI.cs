using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreGameUI : MonoBehaviour 
{
    private TextMeshProUGUI _tekTMP;

    private ScoreManager _scoreManager;

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
        _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
	}

	void UpdateScore()
	{
		_tekTMP.text = _scoreManager.TekScore.ToString();
	}
}
