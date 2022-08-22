using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickManager : MonoBehaviour
{
    public static JoyStickManager instance;

    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        joystickOriginalPos = joystick.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 2;
    }
    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }
    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragpos = pointerEventData.position;
        joystickVec = (dragpos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragpos, joystickTouchPos);

        if (joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
    }
}
