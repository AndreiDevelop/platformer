using UnityEngine;
using System.Collections;

public enum PointState 
{
    None,
    Empty,
    Else
}

public class Point : MonoBehaviour
{
    public int state;

    void OnEnable()
    {
        state = (int)PointState.Empty;
    }
}

public class PointMap : MonoBehaviour {

    public Vector2 koefForGeneratePointsMap;
    public Vector2 pointMapSize;
    public GameObject[,] map;
	// Use this for initialization
	void Start () 
    {
        map = new GameObject[(int)pointMapSize.x, (int)pointMapSize.y];
        GeneratePointsMap(koefForGeneratePointsMap.x, koefForGeneratePointsMap.y);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    //генерируем карту точек
    void GeneratePointsMap(float a, float b)
    {
        GameObject tempGameObject = new GameObject();
        for (int i = 0; i < pointMapSize.x; i++)
        {
            for (int j = 0; j < pointMapSize.y; j++)
            {
                Vector3 newPos = new Vector3(transform.position.x+(float)i * a, transform.position.y+(float)j * b, 0f);
                map[i, j] = (GameObject)Instantiate(tempGameObject, newPos, Quaternion.identity, transform);

                map[i, j].AddComponent<Point>();
            }       
        }
        Destroy(tempGameObject);
    }

    void OnDrawGizmos()
    {
        foreach(Transform wayPoint in transform)
            Gizmos.DrawSphere(wayPoint.position, 0.3f);
    }
}
