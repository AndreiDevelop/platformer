using UnityEngine;
using System.Collections;

public class SensorController : MonoBehaviour, IControllerMove {

    [SerializeField]
    private SensorButton _left;

    [SerializeField]
    private SensorButton _right;

    [SerializeField]
    private SensorButton _up;

    public bool LeftDirection()
    {
        return _left.Press;
    }

    public bool RightDirection()
    {
        return _right.Press;
    }

    public bool UpDirection()
    {
        return _up.Press;
    }

    public bool ControllerActive()
    {
        return true;
    }
}
