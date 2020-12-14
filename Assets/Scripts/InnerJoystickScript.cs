using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerJoystickScript : MonoBehaviour
{
    public Vector2 movementVector = Vector2.zero;
    public float maxDistance = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if there are any touches on the screen
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //get the position in world space of the touch position
            Vector2 innerJoystickPos;
            innerJoystickPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            //move the joystick button to the touch position
            transform.position = innerJoystickPos;
        }
        else if (Input.touchCount < 1)
        {
            //if the screen isn't being touched, revert to initial position
            transform.localPosition = Vector2.zero;
        }
        //check to see if there are any touches on the screen
        if (Input.touchCount > 0)
        {
            //get the position in world space of the touch position
            Touch newTouch = Input.GetTouch(0);
            Vector2 innerJoystickPos;
            innerJoystickPos = new Vector2(Camera.main.ScreenToWorldPoint(newTouch.position).x, Camera.main.ScreenToWorldPoint(newTouch.position).y);
            //move the joystick button to the touch position
            transform.position = innerJoystickPos;
        }
        else if (!Input.GetKey(KeyCode.Mouse0))
        {
            //if the screen isn't being touched, revert to initial position
            transform.localPosition = Vector2.zero;
        }
        //make sure the joystick stays inside the circle area
        transform.localPosition = Vector2.ClampMagnitude(transform.localPosition, maxDistance);
        //normalize local vector
        movementVector = new Vector2(transform.localPosition.x * (1/maxDistance), transform.localPosition.y * (1/maxDistance));
        //keep joystick in front
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.1f);
    }
}
