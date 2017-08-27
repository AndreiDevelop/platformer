using UnityEngine;
using System.Collections;
using System.IO;

public class JsonFileSaveManager<T>: MonoBehaviour 
{
    public T saveObject;
    string fileDataPath=string.Empty;

	void Start () 
    {
        fileDataPath = Application.streamingAssetsPath+"saveJSON.json"; 
        	
    }

    void putToFile()
    {
        //переводим в json
        string bufString = JsonUtility.ToJson(saveObject);  
        File.WriteAllText(fileDataPath,bufString);
    }

    void getFromFile(ref T newObj)
    {
        if (File.Exists(fileDataPath))
        {
            string bufString = File.ReadAllText(fileDataPath);

            JsonUtility.FromJsonOverwrite(bufString, newObj); 
        }
        else
        {
            Debug.Log("File dont exist");
        }
    }
}
