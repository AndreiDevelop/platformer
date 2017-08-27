using UnityEngine;
using System.Collections;

public class PlatformJumpLimit : Platform {

    public int jumpCounter;
    public int scoreJump;

    void Awake()
    {
        _scoreForJump = scoreJump;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hero")
        {
            jumpCounter--; 
            CheckJumpCounter();
        }
    }

    void CheckJumpCounter()
    {
        if (jumpCounter <= 0)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
