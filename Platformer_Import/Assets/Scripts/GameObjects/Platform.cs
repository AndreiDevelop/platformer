using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour 
{
    protected int _scoreForJump=10;

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == TagConstant.HERO)
        {
            ScoreManager.TekScore += _scoreForJump;
        }
    }
}
