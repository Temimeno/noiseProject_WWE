using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class movementJoystick : MonoBehaviour
{
    public GameObject joyStick;
    public GameObject joyStickBG;
    public Vector2 joyStickVector;

    Vector2 joyStickTouchPos;
    Vector2 joyStickOriginalPos;
    float joyStickRadius;

    // Start is called before the first frame update
    void Start()
    {
        joyStickOriginalPos = joyStickBG.transform.position;
        joyStickRadius = joyStickBG.GetComponent<RectTransform>().sizeDelta.y/4;
    }

    public void PointerDown()
    {
        joyStick.transform.position = Input.mousePosition;
        joyStickBG.transform.position = Input.mousePosition;
        joyStickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joyStickVector = (dragPos -joyStickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joyStickTouchPos);

        if(joystickDist < joyStickRadius)
        {
            joyStick.transform.position = joyStickTouchPos + joyStickVector * joystickDist;
        } else

        {
            joyStick.transform.position = joyStickTouchPos + joyStickVector * joyStickRadius;
        }
    }

    public void PointerUp()
    {
        joyStickVector = Vector2.zero;
        joyStick.transform.position = joyStickOriginalPos;
        joyStickBG.transform.position = joyStickOriginalPos;
    }
}
