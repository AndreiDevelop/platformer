using UnityEngine;
using System.Collections;

public class PointMap : MonoBehaviour 
{
    public Vector2 pointMapSize;
    public GameObject[,] map;

	[SerializeField]
	private Vector2 _koefForGeneratePointsMap;

	private Transform _currentTransform;
	// Use this for initialization
	void Awake () 
    {
		_currentTransform = transform;
        map = new GameObject[(int)pointMapSize.x, (int)pointMapSize.y];
        GeneratePointsMap(_koefForGeneratePointsMap.x, _koefForGeneratePointsMap.y);
	}

    //генерируем карту точек
    void GeneratePointsMap(float a, float b)
    {
        GameObject tempGameObject = new GameObject();
        for (int i = 0; i < pointMapSize.x; i++)
        {
            for (int j = 0; j < pointMapSize.y; j++)
            {
				Vector3 newPos = new Vector3(_currentTransform.position.x+(float)i * a, _currentTransform.position.y+(float)j * b, 0f);
				map[i, j] = (GameObject)Instantiate(tempGameObject, newPos, Quaternion.identity, _currentTransform);
            }       
        }
        Destroy(tempGameObject);
    }

//    void OnDrawGizmos()
//    {
//		foreach(Transform wayPoint in _currentTransform)
//            Gizmos.DrawSphere(wayPoint.position, 0.3f);
//    }
}
