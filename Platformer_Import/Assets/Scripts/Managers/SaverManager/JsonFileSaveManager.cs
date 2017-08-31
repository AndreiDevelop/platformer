using UnityEngine;
using System.Collections;
using System.IO;

using System;
using System.Runtime.Serialization;

[DataContract]
struct SaveGameData
{
	[DataMemberAttribute]
	public int gameCount;

	[DataMemberAttribute]
	public int score;

	[DataMemberAttribute]
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
	private SaveGameData []_tekSaveGameData;

	void Start () 
    {
        _fileDataPath = Application.streamingAssetsPath+"SaveJSON.json";  	
    }

	public void SaveProgress()
	{
		if (File.Exists(_fileDataPath)) 
		{
			JsonFileSaver<SaveGameData>.getFromFile (_fileDataPath, ref _tekSaveGameData);

			_tekSaveGameData[_tekSaveGameData.Length-1].SetSaveGameData (++_tekSaveGameData[_tekSaveGameData.Length-1].gameCount);
		} 
		else 
		{
			_tekSaveGameData[_tekSaveGameData.Length-1].SetSaveGameData (1);
		}

		JsonFileSaver<SaveGameData>.putToFile (_fileDataPath, _tekSaveGameData);
	}
}
