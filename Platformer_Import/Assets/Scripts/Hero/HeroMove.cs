using UnityEngine;
using System.Collections;

public class HeroMove : MonoBehaviour, IMove
{
    public Vector2 tekVelocity;
    public float speed;
    public float jumpForce;
    public LayerMask whatIsGround;

    public GlobalController _moveControll;

    private Rigidbody2D _tekRigitBody;
    private bool _onGround;
    private float _heroRadius;
    private Vector2 _startHeroPos;
	// Use this for initialization
	void Start () 
    {
        _moveControll = GameObject.FindObjectOfType<GlobalController>();

        _tekRigitBody = GetComponent<Rigidbody2D>();
        _heroRadius = GetComponent<CircleCollider2D>().radius;
        _startHeroPos = new Vector2(transform.position.x, transform.position.y);
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
        _tekRigitBody.AddForce(new Vector2(-speed, 0f));
    }

    public void MoveRight()
    {
        _tekRigitBody.AddForce(new Vector2(speed, 0f));
    }

    public void MoveUp()
    {
        _tekRigitBody.AddForce(new Vector2(0f, jumpForce));

        _tekRigitBody.velocity=new Vector2(_tekRigitBody.velocity.x,
                Mathf.Clamp(_tekRigitBody.velocity.y,0f,7f));
    }


    void GroundCheckFunction()
    {
        //касаемся ли земли
        _onGround = Physics2D.OverlapCircle(transform.position, _heroRadius, whatIsGround);
    }

    public void ResetHeroMoveAndPosition()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0f;
        transform.position = new Vector3(_startHeroPos.x, _startHeroPos.y, transform.position.z);
    }

    public void Freeze(bool freeze)
    {
        if (freeze)
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        else
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
