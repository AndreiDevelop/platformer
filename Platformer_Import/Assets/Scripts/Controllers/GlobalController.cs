using UnityEngine;
using System.Collections;

public class GlobalController : MonoBehaviour{

    private IControllerMove _movecontroller;
    private GameObject _sensorButtons;
	// Use this for initialization
    #region singleton

    private static GlobalController _instance;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);

       // DontDestroyOnLoad(gameObject);

        _sensorButtons = GameObject.Find("SensorButtons");

        #if UNITY_ANDROID || UNITY_IOS
            _movecontroller = GameObject.FindObjectOfType<SensorController>(); ; 
        #elif UNITY_STANDALONE
            _movecontroller = GameObject.FindObjectOfType<KeyboardController>(); 
            _sensorButtons.SetActive(false);
        #endif
            
    }

    #endregion

    public bool LeftDirection()
    {
        return _movecontroller.LeftDirection();
    }

    public bool RightDirection()
    {
        return _movecontroller.RightDirection();
    }

    public bool UpDirection()
    {
        return _movecontroller.UpDirection();
    }

    public bool ControllerActive()
    {
        return _movecontroller.ControllerActive();
    }
}
