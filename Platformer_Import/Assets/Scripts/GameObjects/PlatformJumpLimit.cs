using UnityEngine;
using System.Collections;

public class PlatformJumpLimit : Platform 
{
	[SerializeField]
    private int _jumpCounter;

	[SerializeField]
	private int _scoreJump;

	private BoxCollider2D _boxCollider;
	private Rigidbody2D _rigitbody;

    void Awake()
    {
        _scoreForJump = _scoreJump;
		_boxCollider = GetComponent<BoxCollider2D> ();
		_rigitbody = GetComponent<Rigidbody2D> ();
    }

    void OnCollisionExit2D(Collision2D col)
    {
		if (col.gameObject.tag == TagConstant.HERO)
        {
            _jumpCounter--; 
            CheckJumpCounter();
        }
    }

    void CheckJumpCounter()
    {
        if (_jumpCounter <= 0)
        {
			_rigitbody.constraints = RigidbodyConstraints2D.None;
			_rigitbody.constraints = RigidbodyConstraints2D.FreezePositionX;
			_rigitbody.constraints = RigidbodyConstraints2D.FreezeRotation;

			_boxCollider.isTrigger = true;
        }
    }
}
