using UnityEngine;
using System.Collections;

public class ObjectLocationManager : MonoBehaviour 
{
    public PoolManager poolManagerCoin;

    public PoolManager poolManagerPlatformNormal;
    public PoolManager poolManagerPlatformOnceJump;
    public PoolManager poolManagerPlatformTwoJump;

    public PointMap pointMapForPlatform;
    public PointMap pointMapForCoin;

    void Start()
    {
        CreateLevelCoin();
        CreateLevelPlatform();
       
    }
	
    void Update()
    {
        
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
        for (int i = 0; i < pointMapForPlatform.pointMapSize.x; i++)
        {
            for (int j = 0; j < pointMapForPlatform.pointMapSize.y; j++)
            {
                InstanceObjectFromPool(PoolObjectChoicerPlatform(),
                    new Vector2(pointMapForPlatform.map[i,j].transform.position.x, pointMapForPlatform.map[i,j].transform.position.y));
            }
        }
    }

    void CreateLevelCoin()
    {
        for (int i = 0; i < pointMapForCoin.pointMapSize.x; i++)
        {
            for (int j = 0; j < pointMapForCoin.pointMapSize.y; j++)
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
                return poolManagerPlatformNormal;
            else if (rand <= 90)
                return poolManagerPlatformOnceJump;
            return poolManagerPlatformTwoJump;
        }
        return null;
    }

    PoolManager PoolObjectChoicerCoin()
    {
        int rand = Random.Range(0, 100);

        if(rand >= 40)
            return poolManagerCoin;
        return null;
    }
}
