using UnityEngine;
using System.Collections;

public class HeroMove : MonoBehaviour, IMove
{
    public Vector2 tekVelocity;
    public float speed;
    public float jumpForce;
    public LayerMask whatIsGround;

    public GlobalController _moveControll;

	private Rigidbody2D _currentRigitBody;
    private bool _onGround;
    private float _heroRadius;
    private Vector2 _startHeroPos;
	private Transform _currentTransform;
	// Use this for initialization
	void Start () 
    {
        _moveControll = GameObject.FindObjectOfType<GlobalController>();

        _currentRigitBody = GetComponent<Rigidbody2D>();
        _heroRadius = GetComponent<CircleCollider2D>().radius;
        _startHeroPos = new Vector2(transform.position.x, transform.position.y);
		_currentTransform = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {       
        if (_moveControll.ControllerActive())
        {
            GroundCheckFunction();
            if (_onGround)
            {
                if (_moveControll.LeftDirection())
                    MoveLeft();
                if (_moveControll.RightDirection())
                    MoveRight();
                if (_moveControll.UpDirection())
                    MoveUp(); 
            }
        }
	}

    public void MoveLeft()
    {
        _currentRigitBody.AddForce(new Vector2(-speed, 0f));
    }

    public void MoveRight()
    {
        _currentRigitBody.AddForce(new Vector2(speed, 0f));
    }

    public void MoveUp()
    {
        _currentRigitBody.AddForce(new Vector2(0f, jumpForce));

        _currentRigitBody.velocity=new Vector2(_currentRigitBody.velocity.x,
                Mathf.Clamp(_currentRigitBody.velocity.y,0f,7f));
    }


    void GroundCheckFunction()
    {
        //касаемся ли земли
		_onGround = Physics2D.OverlapCircle(_currentTransform.position, _heroRadius, whatIsGround);
    }

    public void ResetHeroMoveAndPosition()
    {
		_currentRigitBody.velocity = Vector2.zero;
		_currentRigitBody.angularVelocity = 0f;
		_currentTransform.position = new Vector3(_startHeroPos.x, _startHeroPos.y, _currentTransform.position.z);
    }

    public void Freeze(bool freeze)
    {
        if (freeze)
			_currentRigitBody.constraints = RigidbodyConstraints2D.FreezeAll;
        else
			_currentRigitBody.constraints = RigidbodyConstraints2D.None;
    }
}
