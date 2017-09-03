using System;
using System.IO;
using UnityEngine;
using System.Text;

public class JsonFileSaver<T>
{
	public static void putToFile(string fileDataPathWrite, T saveObject)
	{
		string bufString = JsonUtility.ToJson(saveObject);  
		File.WriteAllText(fileDataPathWrite,bufString);
	}

	public static void getFromFile(string fileDataPathRead,ref T newObj)
	{
		if (File.Exists(fileDataPathRead))
		{
			string bufString = File.ReadAllText(fileDataPathRead);

			newObj = JsonUtility.FromJson<T>(bufString); 
		}
		else
		{
			Debug.Log("File dont exist");
		}
	}
}
