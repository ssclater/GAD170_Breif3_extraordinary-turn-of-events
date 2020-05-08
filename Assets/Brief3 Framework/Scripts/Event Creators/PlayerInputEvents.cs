
using UnityEngine;
using UnityEngine.Events;

/*
    Script: PlayerInputEvents
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script for invoking a UnityEvent when a key is pressed on the keyboard.
*/

public class PlayerInputEvents : MonoBehaviour
{
    // Events
    public UnityEvent keyPressedEvent;              // Invoked whenever the key is pressed.
    public UnityEvent keyReleasedEvent;             // Invoked whenever the key is released.
    public UnityEvent keyNotPressedEvent;           // Invoked each Update() if the key is NOT pressed.

    // Properties
    public KeyCode key = KeyCode.Space;             // The key to press to invoke the 'key pressed' event.

    private bool wasKeyLastPressed;                 // Internal boolean for tracking if the key was down last Update()

    // Methods
    private void Update()
    {
        // If key is pressed, check to invoke event.
        if( Input.GetKey( this.key ) == true )
        {
            if( this.keyPressedEvent != null )    // Check some methods have subscribed to the keyPressedEvent.
                this.keyPressedEvent.Invoke();    // Invoke any methods that have subscribed to the keyPressedEvent.


            // Record the key is pressed for next Update()
            this.wasKeyLastPressed = true;
        }
        else
        {
            // Check if the key was released since last Update()
            if( this.wasKeyLastPressed == true )
            {
                if( this.keyReleasedEvent != null )     // Check some methods have subscribed to the keyReleasedEvent.
                    this.keyReleasedEvent.Invoke();     // Invoke any methods that have subscribed to the keyReleasedEvent.
               
            }
            else
            {
                if( this.keyNotPressedEvent != null )     // Check some methods have subscribed to the keyNotPressedEvent.
                    this.keyNotPressedEvent.Invoke();     // Invoke any methods that have subscribed to the keyNotPressedEvent.
            }

            // Record the key is not pressed for next Update()
            this.wasKeyLastPressed = false;
        } 
    }
}
