using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SaveGameData
{
	public delegate void ChangeGameCount();
	public static event ChangeGameCount OnChangeGameCount;

	private static int _currentGameCount;		//текущее количество сыгранных игр
	public static int CurrentGameCount
	{
		get 
		{
			return _currentGameCount;
		}
		private set 
		{
			_currentGameCount = value;
		}
	}

	public List<int> gameCount;				//количество сыгранных игр
	public List<int> score;					//счет в игре
	public List<int> timeInSeconds;			//время игры в секундах

	public void SetSaveGameData(SaveGameData buf)
	{
		gameCount = new List<int> ();
		score = new List<int> ();
		timeInSeconds = new List<int> ();

		if (buf == null) 
		{
			gameCount.Add (1);
			CurrentGameCount = 1;
		} 
		else 
		{
			gameCount.AddRange (buf.gameCount);
			score.AddRange (buf.score);
			timeInSeconds.AddRange (buf.timeInSeconds);

			gameCount.Add (++buf.gameCount[buf.gameCount.Count - 1]);
			CurrentGameCount = ++buf.gameCount [buf.gameCount.Count - 1];
		}

		score.Add (ScoreManager.TekScore);
		timeInSeconds.Add (GameObject.FindObjectOfType<TimeManager> ().TimeInSecondsSinceStartGame);

		if (OnChangeGameCount != null)
			OnChangeGameCount ();
	}
}

public class JsonFileSaveManager: MonoBehaviour 
{
	private const string CURRENT_FILE_NAME = "SaveJSON.json";

    private string _fileDataPath=string.Empty;
	private SaveGameData _currentSaveGameData;
	private SaveGameData _newSaveGameData;

	void Start () 
    {
		_fileDataPath = Application.streamingAssetsPath + CURRENT_FILE_NAME;  

		_currentSaveGameData = new SaveGameData ();
		_newSaveGameData = new SaveGameData ();
    }

	public void SaveProgress()
	{
		//если сохранения существуют
		if (File.Exists(_fileDataPath)) 
		{
			//считываем сохранения
			JsonFileSaver<SaveGameData>.getFromFile (_fileDataPath, ref _currentSaveGameData);

			_newSaveGameData.SetSaveGameData (_currentSaveGameData);
		} 
		else 
		{
			_newSaveGameData.SetSaveGameData (_currentSaveGameData);
		}

		//записываем сохранения
		JsonFileSaver<SaveGameData>.putToFile (_fileDataPath, _newSaveGameData);
	}
}
