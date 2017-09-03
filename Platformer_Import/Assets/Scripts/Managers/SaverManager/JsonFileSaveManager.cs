using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

struct SaveGameData
{
	public delegate void ChangeGameCount();
	public static event ChangeGameCount OnChangeGameCount;

	public List<int> gameCount;
	public List<int> score;
	public List<int> timeInSeconds;

	public void SetSaveGameData(int currentGameCount)
	{
		if (currentGameCount == 1) 
		{
			gameCount = new List<int> ();
			score = new List<int> ();
			timeInSeconds = new List<int> ();
		}

		gameCount.Add(currentGameCount);
		score.Add(ScoreManager.Instance.TekScore);
		timeInSeconds.Add(GameObject.FindObjectOfType<TimeManager> ().TimeInSecondsSinceStartGame);

		if (OnChangeGameCount != null)
			OnChangeGameCount ();
	}
}

public class JsonFileSaveManager: MonoBehaviour 
{
    private string _fileDataPath=string.Empty;
	private SaveGameData _tekSaveGameData;

	void Start () 
    {
        _fileDataPath = Application.streamingAssetsPath+"SaveJSON.json";  	
    }

	public void SaveProgress()
	{
//		if (File.Exists(_fileDataPath)) 
//		{
//			JsonFileSaver<SaveGameData>.getFromFile (_fileDataPath, ref _tekSaveGameData);
//
//			_tekSaveGameData.SetSaveGameData (++_tekSaveGameData.gameCount[_tekSaveGameData.gameCount.Count - 1]);
//		} 
//		else 
//		{
//			_tekSaveGameData.SetSaveGameData (1);
//		}
//
//		JsonFileSaver<SaveGameData>.putToFile (_fileDataPath, _tekSaveGameData);

		_tekSaveGameData.SetSaveGameData (1);
		Debug.Log ("SAVE DATA" + _tekSaveGameData.gameCount[0] + _tekSaveGameData.score[0] + _tekSaveGameData.timeInSeconds[0]);
	}
}
