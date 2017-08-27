using UnityEngine;
using System.Collections;

public class CamFollowScript : MonoBehaviour {
    public float speed;
    private GameObject _targetFollow;
	// Use this for initialization
	void Start () 
    {
        _targetFollow = GameObject.FindWithTag("Hero");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        float xPos = Mathf.Lerp(transform.position.x, _targetFollow.transform.position.x, speed);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
	}
}
