using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreGameUI : MonoBehaviour 
{
    enum Score{PlatformNormal=10,PlatformOnceJump=20,PlatformTwoJump=30}
    private TextMeshProUGUI _tekTMP;

    private ScoreManager _scoreManager;

	// Use this for initialization
	void Start () 
    {
        _tekTMP = GetComponent<TextMeshProUGUI>();
        _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        _tekTMP.text = _scoreManager.TekScore.ToString();
	}
}
