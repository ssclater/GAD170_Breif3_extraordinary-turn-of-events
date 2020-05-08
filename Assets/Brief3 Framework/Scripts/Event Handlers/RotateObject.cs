using UnityEngine;

/*
    Script: RotateObject
    Author: Gareth Lockett
    Version: 1.0
    Description:    Simple script for rotating an object around its local axis.

                    Usage: Call the RotateXAxisClockwise(), RotateXAxisAntiClockwise(), RotateYAxisClockwise(), RotateYAxisAntiClockwise(), RotateZAxisClockwise(), and RotateZAxisAntiClockwise()
                            methods from UnityEvents (or other scripts) to execute them.

                            Optional: Can lock the local X,Y,Z axis if needed.
*/

public class RotateObject : MonoBehaviour
{
    // Properties
    public float rotationSpeed = 45f;                   // How fast (in degress per second) the object will be rotated.

    public bool lockXAxis, lockYAxis, lockZAxis;        // Options for locking local X,Y,Z axis so they are always zero.

    // Methods
    private void Update()
    {
        // Keeps the local Y axis locked to zero.
        Vector3 eulerAngles = this.transform.eulerAngles;
        if( this.lockXAxis == true ) { eulerAngles.x = 0f; }
        if( this.lockYAxis == true ) { eulerAngles.y = 0f; }
        if( this.lockZAxis == true ) { eulerAngles.z = 0f; }
        this.transform.eulerAngles = eulerAngles;
    }

    public void RotateXAxisClockwise()
    {
        // Rotate clockwise around the X axis.
        this.transform.Rotate( this.transform.right, this.rotationSpeed * Time.deltaTime );
    }

    public void RotateXAxisAntiClockwise()
    {
        // Rotate anti-clockwise around the X axis.
        this.transform.Rotate( this.transform.right, -this.rotationSpeed * Time.deltaTime );
    }

    public void RotateYAxisClockwise()
    {
        // Rotate clockwise around the Y axis.
        this.transform.Rotate( this.transform.up, this.rotationSpeed * Time.deltaTime );
    }

    public void RotateYAxisAntiClockwise()
    {
        // Rotate anti-clockwise around the Y axis.
        this.transform.Rotate( this.transform.up, -this.rotationSpeed * Time.deltaTime );
    }

    public void RotateZAxisClockwise()
    {
        // Rotate clockwise around the Z axis.
        this.transform.Rotate( this.transform.forward, this.rotationSpeed * Time.deltaTime );
    }

    public void RotateZAxisAntiClockwise()
    {
        // Rotate anti-clockwise around the Z axis.
        this.transform.Rotate( this.transform.forward, -this.rotationSpeed * Time.deltaTime );
    }
    
}
