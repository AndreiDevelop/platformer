using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hero")
        {
            gameObject.SetActive(false);
        }
    }
}
