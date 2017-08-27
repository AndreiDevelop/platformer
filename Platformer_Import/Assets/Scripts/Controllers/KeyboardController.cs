using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour, IControllerMove {

    private const float ZERO = 0f;
    private float _horizontalDirection;
    private float _verticalDirection;
    private bool _input;

    // Update is called once per frame
    void Update () 
    {
        _input = Input.anyKey;

        if (_input)
        {
            _horizontalDirection = Input.GetAxis("Horizontal");
            _verticalDirection = Input.GetAxis("Vertical");
        }
    }

    public bool LeftDirection()
    {
        return _horizontalDirection<ZERO;
    }

    public bool RightDirection()
    {
        return _horizontalDirection>ZERO;
    }

    public bool UpDirection()
    {
        return _verticalDirection>ZERO;
    }

    public bool ControllerActive()
    {
        return _input;
    }
}
