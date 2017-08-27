using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PoolManager : MonoBehaviour 
{ 
    private List<GameObject> _poolObjectsList;//список текущих объектов в пуле  

    [SerializeField]
    private GameObject _prefab;            //префаб объекта

    //общее количество объектов в пуле
    [SerializeField]
    private int _countObjectsInPool;
    public int CountObjectsInPool
    { 
        get
        {
            return _countObjectsInPool;
        }
    }

    //текущее количество объектов в пуле
    public int TekCountObjectInPool
    {
        get
        {
            return _poolObjectsList.Count;
        }
    }

    public GameObject []_referenceToAllObjectsBeenInPool;

    void Awake()
    {
        _poolObjectsList = new List<GameObject>();
        _referenceToAllObjectsBeenInPool = new GameObject[_countObjectsInPool];
        FillPool();
    }

    //помещаем в пулл
    public void PushToPool(GameObject tekObj)
    {
        if (_poolObjectsList.Count < _countObjectsInPool)
        {
            _poolObjectsList.Add(tekObj);
            tekObj.GetComponent<PoolObject>().Push(transform.position);
        }
    }

    //берем из пула
    public GameObject PopFromPool(Vector2 newPos)
    {
        GameObject buf = new GameObject();

        if (_poolObjectsList.Count > 0)
        {
            buf = _poolObjectsList[_poolObjectsList.Count - 1];
            _poolObjectsList.Remove(buf);
            buf.GetComponent<PoolObject>().Pop(newPos);
        }

        return buf;
    } 

    //создаем объекты и заполняем ими пул объектов
    void FillPool()
    {
        if (_poolObjectsList.Count == 0)
        {
            for (int i = 0; i < _countObjectsInPool; i++)
            {
                GameObject bufPref = (GameObject)Instantiate(_prefab, transform.position, Quaternion.identity, transform);
                _referenceToAllObjectsBeenInPool[i] = bufPref;
                PushToPool(bufPref);
            }
        }
    }

    public void BackAllObjectsToPool()
    {
        for (int i = 0; i < _countObjectsInPool; i++)
            PushToPool(_referenceToAllObjectsBeenInPool[i]);
    }
}
