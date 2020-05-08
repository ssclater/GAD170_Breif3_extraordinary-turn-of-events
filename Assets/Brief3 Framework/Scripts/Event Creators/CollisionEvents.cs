using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
    Script: CollisionEvents
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script for invoking UnityEvents when an object (With a Rigidbody component) collides with a Collider (Set to NOT isTrigger) on this game object.

                    NOTE: Same as TriggerEvents but for collisions instead.
*/

public class CollisionEvents : MonoBehaviour
{
    // Events
    public UnityEvent collisionEntered;             // Invoked whenever an object starts colliding with this object.
    public UnityEvent collisionStayed;              // Invoked whenever an object continues to collide with this object.
    public UnityEvent collisionExited;              // Invoked whenever an object stops colliding with this object.

    // Properties
    public List<GameObject> specificGameObjects;    // If game object references are added here, only the added game objects will trigger collision events. Otherwise leave empty to have any object trigger collision events.

    // Methods
    private void OnCollisionEnter( Collision collision )
    {
        // Check for specific game objects.
        if( this.CheckForSpecificGameObjects( collision.gameObject ) == false ) { return; }

        if( this.collisionEntered != null )       // Check some methods have subscribed to the triggerEntered event.
            this.collisionEntered.Invoke();       // Invoke any methods that have subscribed to the triggerEntered event.
    }

    private void OnCollisionStay( Collision collision )
    {
        // Check for specific game objects.
        if( this.CheckForSpecificGameObjects( collision.gameObject ) == false ) { return; }

        if( this.collisionStayed != null )        // Check some methods have subscribed to the triggerStayed event.
            this.collisionStayed.Invoke();        // Invoke any methods that have subscribed to the triggerStayed event.
    }

    private void OnCollisionExit( Collision collision )
    {
        // Check for specific game objects.
        if( this.CheckForSpecificGameObjects( collision.gameObject ) == false ) { return; }

        if( this.collisionExited != null )        // Check some methods have subscribed to the triggerExited event.
            this.collisionExited.Invoke();        // Invoke any methods that have subscribed to the triggerExited event.
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
