using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public InnerJoystickScript joystickScript;
    public Button Button;
    public GameObject cyan;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //use the normalized vector from the inner joystick script to get direction of movement, multiply by speed to actually move
        transform.Translate(joystickScript.movementVector * speed * Time.deltaTime);

        // check if the button was pressed
        if (Button.isPressed == true)
        {
            //move to other sprite
            transform.position = cyan.transform.position;
            //disable the sprite above the dead body sprite
            cyan.SetActive(false);
        }
        //test
    }
}
