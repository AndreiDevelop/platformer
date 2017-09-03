using System.Collections;
using UnityEngine;
using TMPro;

public class GameCountUI : MonoBehaviour 
{
	private TextMeshProUGUI _tekTMP;

	void OnEnable()
	{
		SaveGameData.OnChangeGameCount += UpdateGameCount;
	}
	void OnDisable()
	{
		SaveGameData.OnChangeGameCount -= UpdateGameCount;
	}
	void Start () 
	{
		_tekTMP = GetComponent<TextMeshProUGUI>();
	}

	void UpdateGameCount()
	{
		_tekTMP.text = SaveGameData.CurrentGameCount.ToString();
	}
}
