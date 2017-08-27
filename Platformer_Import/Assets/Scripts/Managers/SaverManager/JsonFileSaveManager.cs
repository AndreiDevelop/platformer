using UnityEngine;
using System.Collections;
using System.IO;

struct SaveGameData
{
	public int gameCount;
	public int score;
	public int timeInSeconds;

	public void SetSaveGameData(int tekGameCount)
	{
		gameCount = tekGameCount;
		score = GameObject.FindObjectOfType<ScoreManager> ().TekScore;
		timeInSeconds = GameObject.FindObjectOfType<TimeManager> ().TimeInSecondsSinceStartGame;
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
		if (File.Exists(_fileDataPath)) 
		{
			JsonFileSaver<SaveGameData>.getFromFile (_fileDataPath, ref _tekSaveGameData);

			_tekSaveGameData.SetSaveGameData (++_tekSaveGameData.gameCount);
		} 
		else 
		{
			_tekSaveGameData.SetSaveGameData (1);
		}

		JsonFileSaver<SaveGameData>.putToFile (_fileDataPath, _tekSaveGameData);
	}
}
