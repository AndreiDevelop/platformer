using UnityEngine;
using System.Collections;

public class CamFollowScript : MonoBehaviour 
{
	[SerializeField]
    private float _speed;

    private Transform _targetFollow;
	private Transform _currentTransform;
	// Use this for initialization
	void Start () 
    {
		_targetFollow = GameObject.FindWithTag(TagConstant.HERO).GetComponent<Transform>();
		_currentTransform = transform;
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
		float xPos = Mathf.Lerp(_currentTransform.position.x, _targetFollow.position.x, _speed);
		_currentTransform.position = new Vector3(xPos, _currentTransform.position.y, _currentTransform.position.z);
	}
}
