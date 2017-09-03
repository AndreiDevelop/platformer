using UnityEngine;
using System.Collections;

public class ObjectLocationManager : MonoBehaviour 
{
	[SerializeField]
    private PoolManager _poolManagerCoin;

	[SerializeField]
    private PoolManager _poolManagerPlatformNormal;

	[SerializeField]
    private PoolManager _poolManagerPlatformOnceJump;

	[SerializeField]
    private PoolManager _poolManagerPlatformTwoJump;

	[SerializeField]
    private PointMap _pointMapForPlatform;

	[SerializeField]
	private PointMap _pointMapForCoin;

	private Transform _bufTransform;

    void Start()
    {
        CreateLevelCoin();
        CreateLevelPlatform();
    }

    void InstanceObjectFromPool(PoolManager pool, Vector2 newPos)
    {
        if(pool != null)
            pool.PopFromPool(newPos);
    }

    void DeleteObjectToPool(PoolManager pool, GameObject tekObj)
    {
        if(pool != null)
            pool.PushToPool(tekObj);
    }

    void CreateLevelPlatform()
    {
        for (int i = 0; i < _pointMapForPlatform.pointMapSize.x; i++)
        {
            for (int j = 0; j < _pointMapForPlatform.pointMapSize.y; j++)
            {
				_bufTransform = _pointMapForPlatform.map [i, j].transform;

                InstanceObjectFromPool(PoolObjectChoicerPlatform(),
					new Vector2(_bufTransform.position.x, _bufTransform.position.y));
            }
        }
    }

    void CreateLevelCoin()
    {
        for (int i = 0; i < _pointMapForCoin.pointMapSize.x; i++)
        {
            for (int j = 0; j < _pointMapForCoin.pointMapSize.y; j++)
            {
                InstanceObjectFromPool(PoolObjectChoicerCoin(),
                    new Vector2(Random.Range(-30f,30f), Random.Range(-3f,3f)));

            }
        }
    }

    PoolManager PoolObjectChoicerPlatform()
    {
        int rand = Random.Range(0, 100);

        if (rand >= 50)
        {
            if (rand <= 80)
                return _poolManagerPlatformNormal;
            else if (rand <= 90)
                return _poolManagerPlatformOnceJump;
            return _poolManagerPlatformTwoJump;
        }
        return null;
    }

    PoolManager PoolObjectChoicerCoin()
    {
        int rand = Random.Range(0, 100);

        if(rand >= 40)
            return _poolManagerCoin;
        return null;
    }
}
