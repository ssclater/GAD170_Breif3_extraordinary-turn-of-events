using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script: MovingPlatform
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script to be applied to a platform object. Moves the platform back and forth along a selected axis using a sine wave.
                    Make sure to set platform up with a collider set to isTrigger = true (eg there should be a second, non-trigger collider for the character to stand on)
                    When an object, with a rigidbody, enters the collider it will be parented to this object (eg moves with it)
                    When the object exits the collider it will be unparented.
*/

public class MovingPlatform : MonoBehaviour
{
    public enum Axis { X_AXIS, Y_AXIS, Z_AXIS }

    public Axis axis;
    public float moveDistance;
    public float moveSpeed;

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        switch( this.axis )
        {
            case Axis.X_AXIS:
                moveDirection = this.transform.right;
                break;

            case Axis.Y_AXIS:
                moveDirection = this.transform.up;
                break;

            case Axis.Z_AXIS:
                moveDirection = this.transform.forward;
                break;
        }

        this.transform.position += moveDirection * Time.deltaTime * this.moveDistance * Mathf.Sin( Time.time *this.moveSpeed );
    }

    private void OnTriggerEnter( Collider other )
    {
        other.transform.parent = this.transform;
        other.transform.SetParent(this.transform, true);
    }

    private void OnTriggerExit( Collider other )
    {
        other.transform.parent = null;
    }
}
