using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script: MoveInSinWave
    Author: Gareth Lockett
    Version: 1.0
    Description:    Move the object along a set axis over time using a sine wave.

                    Optional: World space or local axis.
                    Optional: Limit sine wave to positive values only.
*/

public class MoveInSinWave : MonoBehaviour
{
    // Enumerators
    public enum Axis { XAXIS, YAXIS, ZAXIS }

    // Properties
    public Axis axis;               // The axis/direction to move the object in.
    public bool worldAxis;          // Will use world XYZ axis instead of objects local XYZ axis.
    public bool positiveSinOnly;    // Will make any sine values positive.

    public float speed = 3f;        // Speed to move this object (Higher is faster)
    public float distance = 5f;     // Maximum distance to move (Eg Amplitude of the sine wave)

    private float timePassed;       // Amount of time that has passed (Whilst this game object is active)
    private Vector3 startPosition;  // The starting position of the object (Eg the position of this object is updated each frame from this starting position, using a sine wave)

    // Methods
    private void Start()
    {
        // Get the starting world position of this object.
        this.startPosition = this.transform.position;
    }

    private void Update()
    {
        // Update the time passed.
        this.timePassed += Time.deltaTime;

        // Start at the original starting position.
        Vector3 newPosition = this.startPosition;

        // Get the move direction via the selected axis.
        Vector3 moveDirection = Vector3.zero;
        if( this.worldAxis == false )
        {
            switch( this.axis )
            {
                case Axis.XAXIS: moveDirection = this.transform.right; break;
                case Axis.YAXIS: moveDirection = this.transform.up; break;
                case Axis.ZAXIS: moveDirection = this.transform.forward; break;
            }
        }
        else
        {
            switch( this.axis )
            {
                case Axis.XAXIS: moveDirection = Vector3.right; break;
                case Axis.YAXIS: moveDirection = Vector3.up; break;
                case Axis.ZAXIS: moveDirection = Vector3.forward; break;
            }
        }

        // Update the new position along the move direction.
        float sineWave = Mathf.Sin( this.timePassed * this.speed );
        if( this.positiveSinOnly == true ) { sineWave = Mathf.Abs( sineWave ); } // Check to keep the sine wave in positive values only.
        newPosition += moveDirection * sineWave * this.distance;

        // Set this objects position to the new position.
        this.transform.position = newPosition;
    }
}
