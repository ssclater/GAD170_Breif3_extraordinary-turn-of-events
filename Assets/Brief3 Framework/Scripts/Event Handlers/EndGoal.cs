using System;
using UnityEngine;

/*
    Script: EndGoal
    Author: Gareth Lockett
    Version: 1.0
    Description:    ...
*/

public class EndGoal : MonoBehaviour
{
    // Actions
    public static Action ballInGoal;        // Actions are like UnityEvents BUT are only used within code (Eg not in the Unity Inspector) Making it 'static' allows any other script to subscribe a method to it (See GameManager)

    // Properties
    public GameObject ball;                 // Reference to the ball game object.

    // Methods
    private void OnTriggerEnter( Collider other )
    {
        // Check if the object triggering is the ball.
        if( other.gameObject == this.ball )
        {
            Debug.Log( "Ball in end goal!" );

            // Check if anything is subscribed to the EndGoal ballInGoal action, if so, invoke it.
            if( EndGoal.ballInGoal != null ) { EndGoal.ballInGoal.Invoke(); }
        }
    }
}
