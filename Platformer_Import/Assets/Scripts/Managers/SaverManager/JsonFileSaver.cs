using System;
using System.IO;
using UnityEngine;
using System.Text;

public class JsonFileSaver<T>
{
	//TODO: сделать массив сохранений в файл
//	public static void putToFile(string fileDataPathWrite, T saveObject)
//	{
//		//переводим в json
//		string bufString = JsonUtility.ToJson(saveObject);  
//		File.AppendAllText(fileDataPathWrite,bufString);
//	}
//
//	public static void getFromFile(string fileDataPathRead,ref T newObj)
//	{
//		if (File.Exists(fileDataPathRead))
//		{
//			string bufString = File.ReadAllText(fileDataPathRead);
//
//			newObj = JsonUtility.FromJson<T>(bufString);
//			//JsonUtility.FromJsonOverwrite(bufString, newObj); 
//		}
//		else
//		{
//			Debug.Log("File dont exist");
//		}
//	}
		public static void putToFile(string fileDataPathWrite, T []saveObject)
		{
				string bufString = JsonUtility.ToJson(saveObject);  
				File.AppendAllText(fileDataPathWrite,bufString);
		}

		public static void getFromFile(string fileDataPathRead,ref T []newObj)
		{
			if (File.Exists(fileDataPathRead))
			{
				string bufString = File.ReadAllText(fileDataPathRead);
	
				newObj = JsonUtility.FromJson<T[]>(bufString);
				//JsonUtility.FromJsonOverwrite(bufString, newObj); 
			}
			else
			{
				Debug.Log("File dont exist");
			}
		}
}
