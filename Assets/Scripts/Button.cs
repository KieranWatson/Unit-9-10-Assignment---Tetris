using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if there are any inputs
        if (Input.touchCount > 0)
        {
            Touch newTouch = Input.GetTouch(0);
            //check to see if the touch is overlapping with the button
            if (Physics2D.Raycast(Camera.main.ScreenToWorldPoint(newTouch.position), Vector2.zero, 0.01f))
            {
                //press the button
                isPressed = true;
            }
        }
        else if (!Input.GetKey(KeyCode.Mouse0))
        {
            //unpress
            isPressed = false;
        }
        //check to see if there are any inputs
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //check to see if the touch is overlapping with the button
            if (Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0.01f))
            {
                //press the button
                isPressed = true;
            }
        }
        else if (Input.touchCount < 1)
        {
            //unpress
            isPressed = false;
        }
    }
}
