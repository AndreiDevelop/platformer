using UnityEngine;

//текущий объект в пуле
[System.Serializable]
public class PoolObject : MonoBehaviour
{
    private GameObject _tekObject;

    private static int _id;
    public static int Id
    { 
        get
        {
            return _id; 
        }
    }

    private bool _inPool;
    public bool InPool
    { 
        get
        {
            return _inPool;
        }
    }

    void Awake()
    {
        _tekObject = transform.GetChild(0).gameObject;

        if(transform.GetChild(0).gameObject.tag == "Coin")
            transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public PoolObject()
    {
        _id++;
        _inPool = false;
    }

    //помещаем объект в пулл
    public void Push(Vector2 prefPosition)
    {
        _inPool = true;
        _tekObject.SetActive(false);
        _tekObject.transform.position = prefPosition;

        transform.GetChild(0).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

       // if(transform.GetChild(0).gameObject.tag != "Coin")
       //     transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;
    }

    //забираем объект из пула
    public void Pop(Vector2 prefPosition)
    {
        _inPool = false;
        _tekObject.SetActive(true);
        _tekObject.transform.position = prefPosition;
    }
}

