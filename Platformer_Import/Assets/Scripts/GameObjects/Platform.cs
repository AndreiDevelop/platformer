using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour 
{
    protected ScoreManager _scoreManager;
    protected int _scoreForJump=10;

    void Start()
    {
        //получаем менеджер очков
        _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Hero")
        {
            _scoreManager.TekScore += _scoreForJump;
        }
    }
}
