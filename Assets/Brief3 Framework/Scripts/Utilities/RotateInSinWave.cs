using UnityEngine;

/*
    Script: RotateInSinWave
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script for rotating this game object around an axis using a sine wave.
*/

public class RotateInSinWave : MonoBehaviour
{
    // Enumerators
    public enum Axis { XAXIS, YAXIS, ZAXIS }

    // Properties
    public Axis axis;                       // The axis/direction to rotate the object around.
    public float speed = 3f;                // Speed to rotate this object (Higher is faster)
    public float amount = 90f;              // Min/max angle to rotate to/from.

    private Quaternion startRotation;       // Start rotation angles.
    private float rotationTime;             // Internal time tracking.

    // Methods
    private void Start()
    {
        // Initialize roation.
        this.startRotation = this.transform.rotation;
    }

    private void Update()
    {
        // Increament the internal time tracking.
        this.rotationTime += Time.deltaTime;

        // Choose the axis to rotate around.
        Vector3 rotationAxis = this.transform.right;
        switch( this.axis )
        {
            case Axis.YAXIS: rotationAxis = this.transform.up; break;
            case Axis.ZAXIS: rotationAxis = this.transform.forward; break;
        }

        // Calculate the new rotation.
        this.transform.rotation = this.startRotation * Quaternion.Euler( rotationAxis * Mathf.Sin( rotationTime * this.speed ) * amount );
    }
}
