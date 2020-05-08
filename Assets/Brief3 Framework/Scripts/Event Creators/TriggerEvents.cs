using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
    Script: TriggerEvents
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script for invoking UnityEvents when an object (With a Rigidbody component) enters/stays/exits a Collider (Set to isTrigger) on this game object.

                    NOTE: Same as CollisionEvents but for triggers instead.
*/

public class TriggerEvents : MonoBehaviour
{
    // Events
    public UnityEvent triggerEntered;               // Invoked whenever an object enters the trigger on this object.
    public UnityEvent triggerStayed;                // Invoked whenever an object stays within the trigger on this object.
    public UnityEvent triggerExited;                // Invoked whenever an object exits the trigger on this object.

    // Properties
    public List<GameObject> specificGameObjects;    // If game object references are added here, only the added game objects will trigger events. Otherwise leave empty to have any object trigger events.

    // Methods
    private void OnTriggerEnter( Collider other )
    {
        // Check for specific game objects.
        if( this.CheckForSpecificGameObjects( other.gameObject ) == false ) { return; }

        if( this.triggerEntered != null )       // Check some methods have subscribed to the triggerEntered event.
            this.triggerEntered.Invoke();       // Invoke any methods that have subscribed to the triggerEntered event.
    }

    private void OnTriggerStay( Collider other )
    {
        // Check for specific game objects.
        if( this.CheckForSpecificGameObjects( other.gameObject ) == false ) { return; }

        if( this.triggerStayed != null )        // Check some methods have subscribed to the triggerStayed event.
            this.triggerStayed.Invoke();        // Invoke any methods that have subscribed to the triggerStayed event.
    }

    private void OnTriggerExit( Collider other )
    {// Check for specific game objects.
        if( this.CheckForSpecificGameObjects( other.gameObject ) == false ) { return; }

        if( this.triggerExited != null )        // Check some methods have subscribed to the triggerExited event.
            this.triggerExited.Invoke();        // Invoke any methods that have subscribed to the triggerExited event.
    }

    // This method will ONLY return false if there is a list of specific game objects and the passed in gameObject is NOT on that list. Otherwise will return true.
    private bool CheckForSpecificGameObjects( GameObject gameObject )
    {
        if( gameObject == null ) { return true; }
        if( this.specificGameObjects == null ) { return true; }
        if( this.specificGameObjects.Count == 0 ) { return true; }
        return this.specificGameObjects.Contains( gameObject );
    }
}
