using UnityEngine;
using System.Collections;

public class ObjectRepeat : MonoBehaviour {
    private Rigidbody2D _tekHero;
    private Vector3 _defaultPosition;

	// Use this for initialization
	void Start () 
    {
        _defaultPosition = transform.position;
        _tekHero = GameObject.Find("Hero").GetComponent<Rigidbody2D>();
	}
	// Update is called once per frame
	void OnBecameInvisible () 
    {
        //если игрок движеться вправо
        if (_tekHero.velocity.x > 0)
        {
            if (tag != "Coin")
            {
                GetComponent<BoxCollider2D>().isTrigger = false;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else
                gameObject.SetActive(true);
        
            transform.position = _defaultPosition + new Vector3(50f, 0f, 0f);
            _defaultPosition = transform.position;
        }
	}
}
