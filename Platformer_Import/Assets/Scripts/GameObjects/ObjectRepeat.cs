using UnityEngine;
using System.Collections;

public class ObjectRepeat : MonoBehaviour 
{
    private Rigidbody2D _tekHero;
    private Vector3 _defaultPosition;
	private BoxCollider2D _boxCollider;
	private Rigidbody2D _rigitbody;

	// Use this for initialization
	void Start () 
    {
        _defaultPosition = transform.position;
		_tekHero = GameObject.Find(TagConstant.HERO).GetComponent<Rigidbody2D>();
		_boxCollider = GetComponent<BoxCollider2D> ();
		_rigitbody = GetComponent<Rigidbody2D> ();
	}
	// Update is called once per frame
	void OnBecameInvisible () 
    {
        //если игрок движеться вправо
        if (_tekHero.velocity.x > 0)
        {
			if (tag != TagConstant.COIN)
            {
				_boxCollider.isTrigger = false;
				_rigitbody.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else
                gameObject.SetActive(true);
        
            transform.position = _defaultPosition + new Vector3(50f, 0f, 0f);
            _defaultPosition = transform.position;
        }
	}
}
