using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[System.Serializable]
public class SensorButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private bool _press;
    public bool Press
    {
        get
        {
            return _press;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _press = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _press = false;
    }
}
